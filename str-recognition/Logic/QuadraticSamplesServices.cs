using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace str_recognition.Logic
{
    public static class QuadraticSamplesServices
    {
        /// <summary>
        /// Creates a quadratic samples library from a given font and set of symbols
        /// </summary>
        /// <param name="font">Font for sample construction</param>
        /// <param name="symbols">Symbols that will be included into the libary</param>
        /// <returns>the library with constructed samples</returns>
        public static SamplesLibrary<QuadraticSample> QSLibFromFont(System.Drawing.Font font, string symbols)
        {
            var qsamplelib = new SamplesLibrary<QuadraticSample>(font.Height);
            int WhiteSpaceWidth=1;
            for (int i = 0; i < symbols.Length; i++)
            {
                var symbol = symbols[i].ToString();
                //it is a problem with the white space for usual fonts
                if (symbol.CompareTo(" ") != 0)
                    qsamplelib.Add(symbol, QSFromFont(font, symbol));
                else
                    qsamplelib.Add(symbol, QSSpaceFromFont(font, out WhiteSpaceWidth));
            }
            qsamplelib.WhiteSpaceWidth = WhiteSpaceWidth;
            return qsamplelib;
        }
        /// <summary>
        /// Generates a quadratic sample for the symbol of the font
        /// </summary>
        /// <param name="font">font for sample generation</param>
        /// <param name="symbol"></param>
        /// <returns>sample based on a symbol</returns>
        public static QuadraticSample QSFromFont(System.Drawing.Font font, string symbol)
        {
            Bitmap bm = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bm);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            sf.Trimming = StringTrimming.None;
            SizeF sz = g.MeasureString(symbol, font, new PointF(0, 0), sf);
            g.Dispose();
            Bitmap sampleBitmap = new Bitmap((int)sz.Width, font.Height);
            Graphics gs = Graphics.FromImage(sampleBitmap);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            gs.FillRectangle(new SolidBrush(Color.White),0,0,sz.Width,font.Height);
            gs.DrawString(symbol, font, drawBrush, new PointF(0, 0), sf);
            gs.Dispose();
            return new QuadraticSample(sampleBitmap);
        }
        /// <summary>
        /// Generates a white space character for a specific font
        /// </summary>
        /// <param name="font">font for a white space sample generation</param>
        /// <returns></returns>
        public static QuadraticSample QSSpaceFromFont(System.Drawing.Font font, out int WhiteSpaceWidth)
        {
            Bitmap bm = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bm);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            sf.Trimming = StringTrimming.None;
            SizeF sz = g.MeasureString("a b", font, new PointF(0, 0), sf);
            SizeF sz2 = g.MeasureString("ab", font, new PointF(0, 0), sf);
            g.Dispose();
            WhiteSpaceWidth = (int)(sz.Width - sz2.Width);
            Bitmap sampleBitmap = new Bitmap(1, font.Height);
            Graphics gs = Graphics.FromImage(sampleBitmap);
            gs.FillRectangle(new SolidBrush(Color.White), 0, 0, 1, font.Height);
            gs.Dispose();
            return new QuadraticSample(sampleBitmap);
        }
        public static string AdditionalSpacesRemover(System.Drawing.Font font, string RecognitionResult)
        {
            string result = "";
            //i1 - position of nonspace character
            //i2 - position of the next whitespace character
            int i1=0, i2=1;
            while(i2 < RecognitionResult.Length)
            {
                if (RecognitionResult[i1].CompareTo(' ') == 0)
                {
                    i1++; i2++; continue;
                }
                else
                {
                    if (RecognitionResult[i2].CompareTo(' ') == 0)
                    {
                        i2++;
                        continue;
                    }
                    else // we have 2 nonspace characters
                    {
                        result += RecognitionResult[i1].ToString();
                        if (i2 - i1 > 1)
                        {
                            if ((double) (i2 - i1) >= GetSpaceBetweenChars(RecognitionResult[i1], RecognitionResult[i2], font))
                                result += " ";                           
                        }
                        i1 = i2;
                        i2 = i1 + 1;
                    }
                }
            }
            return result + RecognitionResult[i1].ToString();;
        }
        private static double GetSpaceBetweenChars(char p, char p_2, Font font)
        {
            Bitmap bm = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bm);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            sf.Trimming = StringTrimming.None;
            string s1 = new string(new char[]{p,' ',p_2});
            string s2 = new string(new char[] { p, p_2 });
            SizeF sz = g.MeasureString(s1,
                font, new PointF(0, 0), sf);
            SizeF sz2 = g.MeasureString(s2,
                font, new PointF(0, 0), sf);
            g.Dispose();
            return Math.Round(sz.Width - sz2.Width, 1);
        }
        public static string RecogniseBitmap<TSample>(SamplesLibrary<TSample> lib, Bitmap bitmap, out long shift, Font font = null) where TSample : Sample
        {
            int delta = bitmap.Height - lib.Height;
            string[] Answers = new string[delta + 1];
            long[] Fines = new long[delta + 1];
            for (int i = 0; i <= delta; i++)
            {
                RImage img = new RImage(bitmap, bitmap.Width, lib.Height, 0, i);
                //find fine and answer for each recognition
                Answers[i] = img.Recognise(lib, out Fines[i]);
            }
            string Answer = Answers[0];
            long minvalue = Fines[0];
            shift = 0;
            for (int i = 0; i < delta + 1; i++)
            {
                if (Fines[i] < minvalue)
                {
                    minvalue = Fines[i];
                    Answer = Answers[i];
                    shift = i;
                }
            }
            if (font != null) return AdditionalSpacesRemover(font, Answer);
            else return Answer;
        }
        public static string RecogniseBitmap(Font font, string symbols, Bitmap bitmap, out long shift)
        {
            SamplesLibrary<QuadraticSample> lib = QSLibFromFont(font,symbols);
            return RecogniseBitmap(lib, bitmap, out shift, font);
        }
    }
}
