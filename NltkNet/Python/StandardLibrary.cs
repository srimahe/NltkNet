﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NltkNet
{
    public static class StandardLibrary
    {
        static StandardLibrary()
        {
            // built-in functions: print, len
            Nltk.Py.ExecuteScript("def __print__(obj):\r\n\tprint obj\r\n" +
                                  "def __len__(obj):\r\n\treturn len(obj)\r\n" +
                                  "def __str__(obj):\r\n\treturn str(obj)\r\n" +
                                  "def __set__(obj):\r\n\treturn set(obj)\r\n" +
                                  "def __list__(obj):\r\n\treturn list(obj)\r\n" +
                                  "def __sorted__(obj):\r\n\treturn sorted(obj)\r\n" +
                                  "def __range__(p1, p2, p3):\r\n\treturn range(start=p1, stop=p2, step=p3)\r\n" +
                                  "def __zip__(*obj):\r\n\treturn zip(*obj)\r\n"
                                  );
        }

        public static void Print(dynamic pyObj) => Nltk.Py.CallFunction("__print__", pyObj);
        public static long Len(dynamic pyObj) => Nltk.Py.CallFunction("__len__", pyObj);
        public static string Str(dynamic pyObj) => Nltk.Py.CallFunction("__str__", pyObj ?? "");
        public static dynamic Set(dynamic pyObj) => Nltk.Py.CallFunction("__set__", pyObj);
        public static dynamic List(dynamic pyObj) => Nltk.Py.CallFunction("__list__", pyObj);
        public static dynamic Sorted(dynamic pyObj) => Nltk.Py.CallFunction("__sorted__", pyObj);
        public static dynamic Range(int start, int stop, int step = 1) => Nltk.Py.CallFunction("__range__", start, stop, step);
        public static dynamic Zip(params dynamic[] objects) =>  Nltk.Py.CallFunction("__zip__", objects);        


        public static void InternalTest()
        {
            var lst = new List<int>() { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            //var lst2 = new List<int>() { 10, 20, 30, 40, 5, 1, 2, 3, 4, 5 };
            var lst2 = new List<string>() { "A", "B", "C" };

            //Print("Len: " + Len(lst));
            //Print("Sorted: " + Str(Sorted(lst)));
            //var tuple = (1, 2, "str");
            //Print("Tuple2List: " + tuple);
            //Print(List(tuple));
            //Print("Set: " + Str(Set(lst)));
            //var range = Range(0, 30, 3);
            //Print("Range: " + Str(List(range)));

            Print("Zip: " + Str(Zip(lst, lst2)));
        }
    }
}
