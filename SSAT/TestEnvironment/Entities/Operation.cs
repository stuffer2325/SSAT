﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestEnvironment.Entities
{
    [Serializable]
    public class Operation
    {
        string _directive;
        [XmlAttribute]
        public string Directive
        {
            get { return _directive; }
            set { _directive = value; }
        }
        string _executor;
        [XmlAttribute]
        public string Executor
        {
            get { return _executor; }
            set { _executor = value; }
        }

        public Operation() { }

        public Operation(string directive, string executor) {
            _directive = directive;
            _executor = executor;
        }
    }
}
