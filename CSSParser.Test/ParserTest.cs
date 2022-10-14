using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Windows.Forms;

namespace CSSParser.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void LineParserCommentTest()
        {

            var parser = new Parser();
            int result = parser.LineParser("* Bootstrap Grid v5.2.2 (https://getbootstrap.com/)");
            Assert.AreEqual(result, 1);

        }

        [TestMethod]
        public void LineParserClassStartTest()
        {

            var parser = new Parser();
            int result = parser.LineParser(":root {");
            Assert.AreEqual(result, 1);

        }

        [TestMethod]
        public void LineParserClassEndTest()
        {

            var parser = new Parser();
            int result = parser.LineParser("}");
            Assert.AreEqual(result, 1);

        }

        [TestMethod]
        public void LineParserClassListTest()
        {

            var parser = new Parser();
            int result = 0;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader stringReader = new StreamReader(openFileDialog.FileName);

                String Line;
                while((Line = stringReader.ReadLine()) != null)
                {
                    result = parser.LineParser(Line);
                }
            }

            Assert.AreEqual(result, 1);

        }

    }
}
