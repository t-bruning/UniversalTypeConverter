using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Conversion_Should_Use_The_BuiltIn_Default_Value_Mappings() {
            var converter = new TypeConverter();
            converter.ConvertTo<bool>('1').Should().Be(true);
            converter.ConvertTo<bool>('t').Should().Be(true);
            converter.ConvertTo<bool>('T').Should().Be(true);
            converter.ConvertTo<bool>('y').Should().Be(true);
            converter.ConvertTo<bool>('Y').Should().Be(true);
            converter.ConvertTo<bool>('j').Should().Be(true);
            converter.ConvertTo<bool>('J').Should().Be(true);

            converter.ConvertTo<bool>('0').Should().Be(false);
            converter.ConvertTo<bool>('n').Should().Be(false);
            converter.ConvertTo<bool>('N').Should().Be(false);
            converter.ConvertTo<bool>('f').Should().Be(false);
            converter.ConvertTo<bool>('F').Should().Be(false);

            converter.ConvertTo<bool>("1").Should().Be(true);
            converter.ConvertTo<bool>("t").Should().Be(true);
            converter.ConvertTo<bool>("T").Should().Be(true);
            converter.ConvertTo<bool>("true").Should().Be(true);
            converter.ConvertTo<bool>("True").Should().Be(true);
            converter.ConvertTo<bool>(".t.").Should().Be(true);
            converter.ConvertTo<bool>(".T.").Should().Be(true);
            converter.ConvertTo<bool>("y").Should().Be(true);
            converter.ConvertTo<bool>("Y").Should().Be(true);
            converter.ConvertTo<bool>("yes").Should().Be(true);
            converter.ConvertTo<bool>("Yes").Should().Be(true);
            converter.ConvertTo<bool>("j").Should().Be(true);
            converter.ConvertTo<bool>("J").Should().Be(true);
            converter.ConvertTo<bool>("ja").Should().Be(true);
            converter.ConvertTo<bool>("Ja").Should().Be(true);

            converter.ConvertTo<bool>("0").Should().Be(false);
            converter.ConvertTo<bool>("-1").Should().Be(false);
            converter.ConvertTo<bool>("f").Should().Be(false);
            converter.ConvertTo<bool>("F").Should().Be(false);
            converter.ConvertTo<bool>("false").Should().Be(false);
            converter.ConvertTo<bool>("False").Should().Be(false);
            converter.ConvertTo<bool>(".f.").Should().Be(false);
            converter.ConvertTo<bool>(".F.").Should().Be(false);
            converter.ConvertTo<bool>("n").Should().Be(false);
            converter.ConvertTo<bool>("N").Should().Be(false);
            converter.ConvertTo<bool>("no").Should().Be(false);
            converter.ConvertTo<bool>("No").Should().Be(false);
            converter.ConvertTo<bool>("nein").Should().Be(false);
            converter.ConvertTo<bool>("Nein").Should().Be(false);

            converter.ConvertTo<char>(true).Should().Be('T');
            converter.ConvertTo<char>(false).Should().Be('F');
        }

    }

}
