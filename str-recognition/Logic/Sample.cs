using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace str_recognition.Logic
{
    /// <summary>
    /// Basic class for all recognition samples
    /// </summary>
    public abstract class Sample
    {
        /// <summary>
        /// Create an empty sample 
        /// </summary>
        /// <param name="width">width of the sample</param>
        public Sample(int width,int height)
        {
            if (width == 0) throw new Exception("The width of the sample cannot be equal to 0");
            _Width = width;
            if (height == 0) throw new Exception("The height of the sampl columne cannot be equal to 0");
            _Height = height;
        }
        /// <summary>
        /// Returns the fine for recognition of image starting from
        /// startingColumn to startingColumn + (width of sample) as 
        /// a given sample
        /// </summary>
        /// <param name="startingColumn">starting column of image for fine calculation</param>
        /// <param name="image">Image for fine calculation</param>
        /// <returns>a fine</returns>
        public long Fine(int startingColumn,ref RImage image)
        {
            long fine = 0;
            for (int i = 0; i < _Width; i++)
            {
                RColumn rcol = image[startingColumn + i];
                fine += Fine(i, ref rcol);
            }
            return fine;
        }
        /// <summary>
        /// Returns the fine for recognition of the column as 
        /// column number "sampleColumnNumber" of the sample
        /// </summary>
        /// <param name="sampleColumn">Number of the sample column</param>
        /// <param name="column">Source column</param>
        /// <returns>a fine</returns>
        public abstract long Fine(int sampleColumnNumber,ref RColumn column);
        /// <summary>
        /// The height of a column in the sample
        /// </summary>       
        protected int _Height;
        /// <summary>
        /// The height of a column in the sample 
        /// </summary>
        public int Height
        {
            get { return _Height; }
        }
        /// <summary>
        /// The number of columns in the sample
        /// </summary>
        protected int _Width;
        /// <summary>
        /// The number of columns in the sample 
        /// </summary>
        public int Width
        {
            get { return _Width; }
        }
    }
    
    /// <summary>
    /// Recognition samples that are based on given images
    /// </summary>
    public class QuadraticSample : Sample, IXmlSerializable
    {
        public override bool  Equals(object obj)
        {
            var sample = (QuadraticSample)obj;
            return Data.Equals(sample.Data);
        }
        /// <summary>
        /// For serilisation purpose only
        /// </summary>
        protected QuadraticSample():base(1,1)
        {
            Data = new RImage(1, 1);
        }
        /// <summary>
        /// Create an empty sample with quadratic fine function
        /// of dimensions width and height
        /// </summary>
        /// <param name="width">width of the sample</param>
        /// <param name="height">height of the sample</param>
        public QuadraticSample(int width, int height)
            : base(width,height)
        {
            Data = new RImage(width, height);
        }
        /// <summary>
        /// Create sample with quadratic fine function
        /// based on bitmap with the same dimensions
        /// </summary>
        /// <param name="bitmap"></param>
        public QuadraticSample(Bitmap bitmap)
            : this(bitmap, bitmap.Width, bitmap.Height)
        {
            return;
        }
        /// <summary>
        /// Create sample with quadratic fine function
        /// of dimensions width and height
        /// based on a bitmap part with top and left 
        /// coordinates startx and starty
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="startx"></param>
        /// <param name="starty"></param>
        public QuadraticSample(Bitmap bitmap,int width,
            int height,int startx=0, int starty=0)
            : base(width, height)
        {
            Data = new RImage(bitmap,width, height,startx,starty);
        }
        /// <summary>
        /// Returns the fine for recognition of the column as 
        /// column number "sampleColumnNumber" of the sample.
        /// It is equal to square of Euclidian distance
        /// between the sampleColumn and the column
        /// </summary>
        /// <param name="sampleColumn">Number of the sample column</param>
        /// <param name="column">Source column</param>
        /// <returns>a fine</returns>
        public override long Fine(int sampleColumnNumber,ref RColumn column)
        {
            return Data[sampleColumnNumber].QuadraticDistance(ref column);
        }
        /// <summary>
        /// Sets or gets the specific column of the sample
        /// </summary>
        /// <param name="columnIndex">Column number</param>
        /// <returns></returns>
        public RColumn this[int columnIndex]
        {
            get
            {
                return Data[columnIndex];
            }
            set
            {
                Data[columnIndex] = value;
            }
        }
        /// <summary>
        /// Sample image
        /// </summary>
        private RImage Data;
        #region IXmlSerializable implementation

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();
            if (reader.Name.CompareTo("SampleImage") != 0)
                throw new Exception("Wrong xml format");
            Data.ReadXml(reader);
            reader.ReadEndElement();
            _Width = Data.Width;
            _Height = Data.Height;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("SampleImage");
            Data.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion
    }

    /// <summary>
    /// recognition samples that are based on linear fine function
    /// </summary>
    public class LinearSample : Sample, IXmlSerializable
    {
        public override bool Equals(object obj)
        {
            var sample = (LinearSample)obj;
            return (DataA.Equals(sample.DataA)) && (DataB.Equals(sample.DataB));
        }
        /// <summary>
        /// For serilisation purpose only
        /// </summary>
        protected LinearSample(): base(1, 1)
        {
            DataA = new RImage(1, 1);
            DataB = new RImage(1, 1);
        }
        /// <summary>
        /// Create an empty sample with quadratic fine function
        /// of dimensions width and height
        /// </summary>
        /// <param name="width">width of the sample</param>
        /// <param name="height">height of the sample</param>
        public LinearSample(int width, int height)
            : base(width, height)
        {
            DataA = new RImage(width, height);
            DataB = new RImage(width, height);
        }
        /// <summary>
        /// Returns the fine for recognition of the column as 
        /// column number "sampleColumnNumber" of the sample.
        /// It is defined by a linear function of a given column
        /// </summary>
        /// <param name="sampleColumn">Number of the sample column</param>
        /// <param name="column">Source column</param>
        /// <returns>a fine</returns>
        public override long Fine(int sampleColumnNumber,ref RColumn column)
        {
            RColumn A = DataA[sampleColumnNumber];
            RColumn B = DataB[sampleColumnNumber];
            return column.LinearFunction(ref A,ref B);
        }
        /// <summary>
        /// The linear sample column corresponding to columnIndex
        /// ParamNumber=1 for a linear koefficient
        /// ParamNumber=1 for a bias
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="ParamNumber"></param>
        /// <returns></returns>
        public RColumn this[int columnIndex,uint ParamNumber]
        {
            get
            {
                if (ParamNumber > 2) throw new Exception("Out of Bound");
                return (ParamNumber == 1) ? DataA[columnIndex] : DataB[columnIndex];
            }
            set
            {
                if (ParamNumber > 2) throw new Exception("Out of Bound");
                if (ParamNumber == 1)
                    DataA[columnIndex] = value;
                else
                    DataB[columnIndex] = value;
            }
        }
        /// <summary>
        /// An array of linear coefficients
        /// </summary>
        private RImage DataA;
        /// <summary>
        /// An array of a biases
        /// </summary>
        private RImage DataB;
        #region IXmlSerializable implementation
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();
            if (reader.Name.CompareTo("DataA") == 0)
            {
                DataA.ReadXml(reader);
                if (reader.Name.CompareTo("DataB") == 0)
                    DataB.ReadXml(reader);
                else
                    throw new Exception("Wrong xml format");
            }
            else if (reader.Name.CompareTo("DataB") == 0)
            {
                DataB.ReadXml(reader);
                if (reader.Name.CompareTo("DataA") == 0)
                    DataA.ReadXml(reader);
                else
                    throw new Exception("Wrong xml format");
            }
            else throw new Exception("Wrong xml format");
            _Width = DataA.Width;
            _Height = DataA.Height;
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("DataA");
            DataA.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteStartElement("DataB");
            DataB.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion
    }
}
