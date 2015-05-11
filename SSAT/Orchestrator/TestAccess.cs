﻿using SATFUtilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using TestEnvironment.Entities;

namespace Orchestrator {
    public class TestAccess : ITestAccess {
        public IList<TestCase> LoadTestCases() {
            var serializer = new XmlSerializer(typeof(TestSuite));
            TestSuite ts;
            // TODO: locate the test-suite file using OpenFileDialog
            using (var reader = new StreamReader("test-suite.xml")) {
                ts = (TestSuite)serializer.Deserialize(reader);
                reader.Close();
            }
            // Get clients' locations based on their names
            var clientCollection = Constants.ClientCollection;
            if (clientCollection != null) {
                foreach (var client in ts.TestCases.SelectMany(t => t.Steps).SelectMany(s => s.Actions).Select(a => a.TargetClient)) {
                    client.IpAddress = IPAddress.Parse(clientCollection[client.Name]);
                }
            }

            return ts.TestCases;
        }

        private void SerializeFakeTestCases() {
            var serializer = new XmlSerializer(typeof(TestSuite));
            var tss = new TestSuite();
            using (var writer = new StreamWriter("test-suite.xml")) {
                serializer.Serialize(writer, tss);
                writer.Close();
            }
        }
    }
}
