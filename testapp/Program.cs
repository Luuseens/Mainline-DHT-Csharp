﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mainlineDHT;
using mainlineDHT.BEncode;

namespace testapp
{
    using System.IO;

    using mainlineDHT.BEncode.Parser;

    class Program
    {
        static void Main(string[] args)
        {
            var outerDic = new BEncodeDictionary();
            var innderDic = new BEncodeDictionary();
            innderDic.Add("id", new BEncodeByteString("...;..o....Mk'.d..c."));
            innderDic.Add("info_hash", new BEncodeByteString(".#=.G.....N.).,l..q."));
            outerDic.Add("a", innderDic);

            outerDic.Add("q", new BEncodeByteString("get_peers"));
            outerDic.Add("t", new BEncodeByteString("...."));
            outerDic.Add("v", new BEncodeByteString("Utw."));
            outerDic.Add("y", new BEncodeByteString("q"));

            var formatted = outerDic.ToBytes();
            var str = Encoding.ASCII.GetString(formatted);
            var filePath = @"C:\Users\b-rendij\Downloads\Family.Guy.S12E13.720p.HDTV.x264-REMARKABLE.torrent";
            
            var str2 = File.ReadAllBytes(filePath);

            byte[] remStr;
            //var parsed = ToEntity.ToEntity("d2:id4:abbae", out remStr);
            var parsed = FromBytes.ToEntity(str2, out remStr) as BEncodeDictionary;

            File.WriteAllBytes(@"C:\Users\b-rendij\Downloads\Family.Guy.S12E13.720p.HDTV.x264-REMARKABLE2.torrent", parsed.ToBytes());

            Debugger.Break();
        }
    }
}