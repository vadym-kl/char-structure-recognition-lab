using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace str_recognition.Logic
{
    /// <summary>
    /// Represents an image for recognition
    /// </summary>
    public class RImage : IXmlSerializable
    {
        public override bool Equals(object obj)
        {
            RImage Object = (RImage) obj;
            if (Object.Height != Height)
                return false;
            if (Object.Width != Width)
                return false;
            for (int i = 0; i < Width; i++)
            {
                if (!Object[i].Equals(this[i])) return false;
            }
            return true;
        }
        /// <summary>
        /// Creates an RImage class from an arbitarary image
        /// </summary>
        /// <param name="bitmap">original bitmap</param>
        public RImage(Bitmap bitmap)
            : this(bitmap, bitmap.Width, bitmap.Height)
        {
            return;
        }
        /// <summary>
        /// Creates an RImage class from an arbitarary image
        /// of dimensions height and width
        /// </summary>
        /// <param name="bitmap">source image</param>
        /// <param name="width">width of image</param>
        /// <param name="height">height of image</param>
        public RImage(Bitmap bitmap, int width, int height, int startx=0, int starty=0)
            : this(width, height)
        {
            Bitmap greyscaleBitmap = ImageProcessing.ImageUtility.MakeGrayscale(bitmap);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //for each pixel of greyscale image
                    //r,g and b values are equal
                    Data[i][j] = greyscaleBitmap.GetPixel(i + startx, j + starty).R;
                }
            }
        }
        /// <summary>
        /// Create an empty image of given dimensions
        /// </summary>
        /// <param name="width">width of a new image</param>
        /// <param name="height">height of a new image</param>
        public RImage(int width, int height)
        {
            InitEmpty(width, height);
        }
        /// <summary>
        /// Performs simple initialisation
        /// </summary>
        /// <param name="width">image width</param>
        /// <param name="height">image height</param>
        public void InitEmpty(int width, int height)
        {
            Data = new RColumn[width];
            for(int i=0;i<width;i++)
            {
                Data[i] = new RColumn(height);
            }
        }
        /// <summary>
        /// Constructs image corresponding to a text 
        /// using samples from samplesLibrary
        /// </summary>
        /// <param name="text">text that will be represented by the image</param>
        /// <param name="samplesLibrary">samples for image building</param>
        public RImage(string text, SamplesLibrary<QuadraticSample> samplesLibrary, bool ExpandSpaces = true):
            this(samplesLibrary.StringWidthInColumns(text, ExpandSpaces), samplesLibrary.Height)
        {
            List<QuadraticSample> Samples;
            samplesLibrary.StringWidthInColumns(text, out Samples, ExpandSpaces);
            int currentColumn = 0;
            foreach(var sample in Samples)
            {
                for (int i = 0; i < sample.Width; i++)
                {
                    Data[currentColumn + i] = (RColumn)sample[i].Clone();
                }
                currentColumn += sample.Width;
            }
        }
        /// <summary>
        /// Sets or gets a column of an image
        /// </summary>
        /// <param name="index">The index of Image column</param>
        /// <returns>Column number "index"</returns>
        public RColumn this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = value;
            }
        }
        /// <summary>
        /// Recognises image using samplesLibrary.
        /// samplesLibrary must have the same height as the image
        /// if you need another return value: contact me :)
        /// </summary>
        /// <param name="samplesLibrary">samplesLibrary for recognition</param>
        /// <param name="Fine">returns a minimal possible fine</param>
        /// <returns>The string the fine for witch is minimal</returns>
        public string Recognise<TSample>(SamplesLibrary<TSample> samplesLibrary, out long Fine)
            where TSample : Sample
        {
            if (Height != samplesLibrary.Height)
                throw new Exception("Samples in the library must have the same height as the image");
            //here we start the recognition procedure
            int CollectionSize = samplesLibrary.Count;
            var Values=samplesLibrary.Values.ToArray();
            var Keys=samplesLibrary.Keys.ToArray();
            long?[,] fines = new long?[CollectionSize, Width + 1];
            int[,] links = new int[CollectionSize, Width + 1];
            //let's fill the first column with fines for each letter
            //starting flom 0 column
            RImage rimg = this;
            for (int currentSample = 0; currentSample < CollectionSize; currentSample++)
                fines[currentSample, 0] = Values[currentSample].Fine(0, ref rimg);
            for (int currentColumn = 1; currentColumn < Width+1; currentColumn++)
            {
                //let's fill i-th column with fines
                //for each sample in the library
                for (int currentSample = 0; currentSample < CollectionSize; currentSample++)
                {
                    var AccessibleSamples = new List<KeyValuePair<int,long>>();
                    //we must determine the previous possible samples
                    //and find one with a minimal fine
                    //let's check each sample in the library
                    for (int PreviousSample = 0; PreviousSample < CollectionSize; PreviousSample++)
                    {
                        //firstly, we should check if it is possible to pose this sample
                        if (Values[PreviousSample].Width <= currentColumn)
                        {
                            var currentFine = fines[PreviousSample,
                                currentColumn - Values[PreviousSample].Width];
                            //and when it is possible to add it to a path
                            if (currentFine != null)
                            {
                                AccessibleSamples.Add(
                                    new KeyValuePair<int,long>(PreviousSample, currentFine ?? 0));
                            }
                        }
                    }
                    
                    //now we have a list of accessible samples and we can find minimum
                    if (AccessibleSamples.Count != 0)
                    {
                        //var keys = AccessibleSamples.Keys.ToArray();
                        //var values = AccessibleSamples.Values.ToArray();
                        long min = AccessibleSamples[0].Value;
                        int minindex = AccessibleSamples[0].Key;
                        foreach (var kp in AccessibleSamples)
                        {
                            if (min > kp.Value)
                            {
                                min = kp.Value;
                                minindex = kp.Key;
                            }
                        }
                        fines[currentSample, currentColumn] = min;
                        links[currentSample, currentColumn] = minindex;
                        //and add the fine for the current sample
                        if (currentColumn < Width)
                        {
                            //we should check if we can start new sample at currentColumn
                            if (currentColumn + Values[currentSample].Width <= Width)
                            {
                                fines[currentSample, currentColumn] +=
                                    Values[currentSample].Fine(currentColumn, ref rimg);
                            }
                        }
                    }
                }
            }
            //finally the last coulmn is filled
            //we can find a string that corresponds to minimal fine
            var Results = new Dictionary<int, long>();
            for (int currentSample = 0; currentSample < CollectionSize; currentSample++)
            {
                if (fines[currentSample, Width] != null)
                {
                    Results.Add(currentSample, fines[currentSample, Width]??0);
                }
            }
            if (Results.Count == 0)
            {
                //there are no possible strings for this image
                //rather strange case, possible if we don't have a samples of width equal to 1
                //and in some other similar cases
                Fine = 0;
                return ""; 
            }
            else
            {
                long min = Results.Min(x => x.Value);
                var minMatchingKVPs = Results.Where(x => x.Value == min);
                //the minimal possible fine
                Fine = min;
                //let's build a string
                string resultString = "";
                int currentColumn = Width;
                int currentSample = minMatchingKVPs.First().Key;
                while(currentColumn!=0)
                {
                    currentSample = links[currentSample,currentColumn];
                    resultString = Keys[currentSample] + resultString;
                    currentColumn = currentColumn - Values[currentSample].Width;
                    if (currentColumn < 0)
                        throw new Exception("Unpredictable bug in the recognition algorithm");
                }
                return resultString;
            }
        }
        /// <summary>
        /// Recognises image using samplesLibrary.
        /// samplesLibrary must have the same height as the image
        /// </summary>
        /// <param name="samplesLibrary">samplesLibrary for recognition</param>
        /// <param name="Fine">returns a minimal possible fine</param>
        /// <returns>The string the fine for witch is minimal</returns>
        public string Recognise<TSample>(SamplesLibrary<TSample> samplesLibrary)
            where TSample:Sample
        {
            long fine=0;
            return Recognise(samplesLibrary,out fine);
        }
        /// <summary>
        /// Adds a gaussian noise to the image
        /// </summary>
        /// <param name="Dispersion">the sigma parameter of the gaussian distribution</param>
        public void AddGaussianNoise(double Dispersion)
        {
            var random = new Random();
            foreach (var column in Data)
            {
                for (int i = 0; i < Height; i++)
                {
                    //Polar Method,  A First Course on Probability by S. M. Ross
                    //lookup here: http://www.dspguru.com/dsp/howtos/how-to-generate-white-gaussian-noise
                    double u1, u2, v1, v2, s, x;
                    do
                    {
                        u1 = random.NextDouble();
                        u2 = random.NextDouble();
                        v1 = 2 * u1 - 1;
                        v2 = 2 * u2 - 1;
                        s = v1 * v1 + v2 * v2;
                    }
                    while (s >= 1);
                    x = Math.Sqrt(-2 * Math.Log(s) / s) * v1;
                    int noise = (int)(Dispersion * x);
                    //fit it into type constraints
                    int a = column[i] + noise;
                    if (a > 255) a = 255;
                    if (a < 0) a = 0;
                    column[i] = (byte)a;
                }
            }
        }
        /// <summary>
        /// height of the image
        /// </summary>
        public int Height
        {
            get { return Data[0].Height; }
        }
        /// <summary>
        /// width of the image
        /// </summary>
        public int Width
        {
            get { return Data.Length; }
        }
        /// <summary>
        /// the image data
        /// </summary>
        private RColumn[] Data;
        /// <summary>
        /// Initialises Image from Base64 encoded string
        /// </summary>
        /// <param name="byteString">Base64 encoded string</param>
        /// <param name="width">new RImage width</param>
        /// <param name="height">new RImage height</param>
        private void FromBase64String(String byteString, int width, int height)
        {
            var byteArray = Convert.FromBase64String(byteString);
            if (byteArray.Length != height * width)
                throw new Exception("The wrong size of the Base64String");
            InitEmpty(width, height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Data[i][j] = byteArray[i * Height + j];
                }
            }

        }
        /// <summary>
        /// Returns a string that can be stored in XML and represents the image
        /// </summary>
        /// <returns>string that represents the image</returns>
        private string ToBase64String()
        {
            //Let's create byte array that represents an Image
            var byteArray = new byte[Width * Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
			    {
                    byteArray[i * Height + j] = Data[i][j];
			    }
            }
            return Convert.ToBase64String(byteArray);
        }
        /// <summary>
        /// Creaate Bitmap from the RImage
        /// </summary>
        /// <returns>Bitmap with data from this RImage</returns>
        public Bitmap GetBitmap()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    byte level = Data[i][j];
                    bmp.SetPixel(i, j, Color.FromArgb(level, level, level));
                }
            }
            return bmp;
        }
        #region IXmlSerializable implementation
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XElement x = (XElement)XNode.ReadFrom(reader);
            int width = (int) x.Attribute("Width");
            int height = (int)x.Attribute("Height");
            string xmlData = (string) x;
            FromBase64String(xmlData, width, height);
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartAttribute("Width");
            writer.WriteValue(Width);
            writer.WriteEndAttribute();
            writer.WriteStartAttribute("Height");
            writer.WriteValue(Height);
            writer.WriteEndAttribute();
            writer.WriteRaw(ToBase64String());
        }
        #endregion
    }

    /// <summary>
    /// Represents a column of an Image
    /// </summary>
    public class RColumn: ICloneable
    {
        public override bool Equals(object obj)
        {
            var sample2 = (RColumn)obj;
            if (Height != sample2.Height)
                throw new Exception("Colums must have the same height");
            for (int i = 0; i < Data.Length; i++)
            {
                if (this[i] != sample2[i]) return false;
            }
            return true;
        }
        /// <summary>
        /// Creates an empty column
        /// </summary>
        /// <param name="height">height of the column</param>
        public RColumn(int height)
        {
            Data = new byte[height];
        }
        /// <summary>
        /// Sets or gets the pixel of the column
        /// </summary>
        /// <param name="index">The index of column pixel</param>
        /// <returns>The value of pixel</returns>
        public byte this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = value;
            }
        }
        public long LinearFunction(ref RColumn A, ref RColumn B)
        {
            long fine = 0;
            int len = Data.Length;
            for (int i = 0; i < len; i++)
            {
                fine += A.Data[i] * Data[i] +
                    B.Data[i];
            }
            return fine;
        }
        public long QuadraticDistance(ref RColumn column)
        {
            long fine = 0;
            int len = Data.Length;
            for (int i = 0; i < len; i++)
            {
                int delta = column.Data[i] - Data[i];
                fine += delta * delta;
            }
            return fine;
        }
        /// <summary>
        /// Height of a column
        /// </summary>
        public int Height
        {
            get { return Data.Length; }
        }
        /// <summary>
        /// Pixels of a column (greyscale)
        /// </summary>
        private byte[] Data;
        /// <summary>
        /// Returns string that represents column data in Base64
        /// </summary>
        /// <returns>string that represents column data in Base64</returns>
        private string ToBase64String()
        {
            return Convert.ToBase64String(Data);
        }
        /// <summary>
        /// Initialises object from string that represents column data in Base64
        /// </summary>
        /// <param name="baseString"></param>
        private void FromBase64String(String baseString)
        {
            Data = Convert.FromBase64String(baseString);
        }
        /// <summary>
        /// Creates the copy of the object
        /// </summary>
        /// <returns>the clone</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
