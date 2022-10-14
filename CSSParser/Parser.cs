using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Parser
    {
        int status = 0;
        public CSSDataType cssDataType;

        public Parser()
        {
            cssDataType = new CSSDataType();
        }

        public int LineParser(String Line)
        {

            if (
                Line.Trim().StartsWith("\\*") ||
                Line.Trim().StartsWith("\\*!") ||
                Line.Trim().StartsWith("*")
            )
            {
                // Comment Line
                return 1; 
            }
            else if (
                Line.Trim().EndsWith("{")
            )
            {
                // Class Start Line
                status = 1;

                String name = Line.Trim(new Char[] { '{', '}', ',' });

                cssDataType.cssClassDataTypes.Add(new CSSClassDataType(name));

                return 1;
            } 
            else if (
                Line.Trim().StartsWith("}")
            )
            {
                // Class End Line
                status = 0;
                return 1;
            }


            return 0;

        }


    }
}
