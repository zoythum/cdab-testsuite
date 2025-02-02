/*
cdab-client is part of the software suite used to run Test Scenarios 
for bechmarking various Copernicus Data Provider targets.
    
Copyright (C) 2020 Terradue Ltd, www.terradue.com
    
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

/*
cdab-client is part of the software suite used to run Test Scenarios 
for bechmarking various Copernicus Data Provider targets.
    
Copyright (C) 2020 Terradue Ltd, www.terradue.com
    
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Net;
using cdabtesttools.Config;
using cdabtesttools.Data;
using cdabtesttools.Target;
using cdabtesttools.TestCases;
using log4net;
using Terradue.OpenSearch.Result;

namespace cdabtesttools.TestScenarios
{
    internal class TestScenario06 : IScenario
    {
        private TargetSiteWrapper target;
        private int load_factor;
        private ILog log;

        public TestScenario06(ILog log, TargetSiteWrapper target, int load_factor)
        {
            this.log = log;
            this.load_factor = load_factor;
            this.target = target;
        }

        public string Id => "TS06";

        public string Title => "Data Latency Analysis";

        internal static bool CheckCompatibility(TargetSiteWrapper target)
        {
            return target.Type == TargetType.DATAHUB || target.Type == TargetType.DIAS;
        }

        public IEnumerable<TestCase> CreateTestCases()
        {
            List<TestCase> _testCases = new List<TestCase>();

            List<IOpenSearchResultItem> foundItems;

            _testCases.Add(new TestCase601(log, target, load_factor, out foundItems));
            _testCases.Add(new TestCase602(log, target, load_factor, out foundItems));

            return _testCases;
        }
    }
}
