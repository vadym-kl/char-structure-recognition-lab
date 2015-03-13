using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace str_recognition.Logic
{

    public class SamplesLibrary<TSample> : SortedDictionary<string, TSample>, IXmlSerializable
        where TSample : Sample
    {
        /// <summary>
        /// Constructor for serialisation purposes only
        /// </summary>
        protected SamplesLibrary()
        {
            _Height = 1;
            WhiteSpaceWidth = 1;
        }
        /// <summary>
        /// Compares two sample libraries
        /// </summary>
        /// <param name="obj">the library to compare with</param>
        /// <returns>true if they are equal, false othewise</returns>
        public override bool  Equals(object obj)
        {
            var slib = (SamplesLibrary<TSample>)obj;
            if (Count != slib.Count) return false;
            foreach (var c in Keys)
            {
                TSample sample;
                if (slib.TryGetValue(c, out sample))
                {
                    if (!slib[c].Equals(sample)) return false;
                }
                else
                    return false;
            }
            return true;
        }

        public string AllSymbols()
        {
            return String.Concat(Keys.ToArray());
        }
        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="height">height of samples in the library</param>
        public SamplesLibrary(int height)
        {
            if(height<=0)throw new Exception("Height must be positive");
            _Height=height;
            WhiteSpaceWidth = 1;
        }
        /// <summary>
        /// Returns the number of columns of Rimage that will represent String
        /// using samples for the library
        /// </summary>
        /// <param name="String">String that must we represented</param>
        /// <returns>width of the image that represents the string</returns>
        public int StringWidthInColumns(string String, bool ExpandSpaces= true)
        {
            List<TSample> Samples;
            return StringWidthInColumns(String, out Samples, ExpandSpaces);
        }
        /// <summary>
        /// Returns the number of columns of Rimage that will represent String
        /// using samples for the library
        /// </summary>
        /// <param name="String">String that must we represented</param>
        /// <param name="Samples">The list of samples that represents the string</param>
        /// <returns>width of the image that represents the string</returns>
        public int StringWidthInColumns(string String,out List<TSample> Samples,bool ExpandSpaces = true)
        {
            Samples = new List<TSample>();        
            var Keys = this.Keys.ToArray();
            var Values = this.Values.ToArray();
            int CurrentPos = 0;
            int CurrentWidth = 0;
            int res = 0;
            while (CurrentPos != String.Length)
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    res = String.IndexOf(Keys[i], CurrentPos);
                    if (res == CurrentPos)
                    {
                        CurrentPos += Keys[i].Length;
                        if (Keys[i].CompareTo(" ") == 0 && ExpandSpaces)
                        {
                            CurrentWidth += Values[i].Width * _WhiteSpaceWidth;
                            for (int k = 0; k < _WhiteSpaceWidth; k++)
                            {
                                Samples.Add(Values[i]);
                            }
                        }
                        else
                        {
                            CurrentWidth += Values[i].Width;
                            Samples.Add(Values[i]);
                        }
                        break;
                    }
                    res = -1;
                }
                if (res == -1)
                    throw new Exception("Wrong string for this SamplesLibrary");
            }
            return CurrentWidth;
        }
        /// <summary>
        /// Height of samples in the library
        /// </summary>
        private int _Height;
        /// <summary>
        /// Height of samples in the library
        /// </summary>
        public int Height
        {
            get { return _Height; }
        }
        private int _WhiteSpaceWidth;
        public int WhiteSpaceWidth
        {
            get { return _WhiteSpaceWidth; }
            set {
                if (value > 0)
                    _WhiteSpaceWidth = value;
                else
                    throw new Exception("Wrong whitespace width");
            }
        }
        /// <summary>
        /// Adds sample to the Library
        /// </summary>
        /// <param name="letter">a sign corresponding to the sample</param>
        /// <param name="value">the sample</param>
        public new void Add(string letter, TSample value)
        {
            if (value.Height != Height)
                throw new Exception("The sample height is different");
            if(letter.Length == 0)//treat "" as " " -- for XML serialisation
                base.Add(" ", value);
            else
                base.Add(letter, value);
        }
        #region IXmlSerializable implementation

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer xs = new XmlSerializer(typeof(WholeLibData));
            reader.ReadStartElement();
            var SerData = (WholeLibData)xs.Deserialize(reader);
            reader.ReadEndElement();
            WhiteSpaceWidth = SerData.WhiteSpaceWidth;
            if(SerData.pairs_list.Count != 0)
            {
                _Height = SerData.pairs_list.First().Sample.Height;
                foreach (var el in SerData.pairs_list)
                {
                    this.Add(el.Key, el.Sample);
                }
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");
            var SerData = new WholeLibData();
            SerData.WhiteSpaceWidth = WhiteSpaceWidth;
            SerData.pairs_list = (List<SampleWithTag>)
                (from c in this.Keys select new SampleWithTag(c, this[c])).ToList();
            XmlSerializer xs = new XmlSerializer(typeof(WholeLibData));
            xs.Serialize(writer, SerData, xmlnsEmpty);
        }
        /// <summary>
        /// Class for a storage of pairs (key,smaple)
        /// </summary>
        public class SampleWithTag
        {
            public TSample Sample;
            public string Key;
            public SampleWithTag(){}
            public SampleWithTag(string key, TSample sample)
            {
                Sample = sample;
                Key = key;
            }
        }
        public class WholeLibData
        {
            public List<SampleWithTag> pairs_list;
            public int WhiteSpaceWidth;
        }
        #endregion 
    }
}
