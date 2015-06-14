﻿namespace AngleSharp.Css.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using AngleSharp.Extensions;
    using AngleSharp.Parser.Css;
    using AngleSharp.Dom.Css;

    sealed class StringValueConverter : IValueConverter
    {
        public IPropertyValue Convert(IEnumerable<CssToken> value)
        {
            var str = value.ToCssString();
            return str != null ? new StringValue(str, value) : null;
        }

        sealed class StringValue : IPropertyValue
        {
            readonly String _value;
            readonly CssValue _original;

            public StringValue(String value, IEnumerable<CssToken> tokens)
            {
                _value = value;
                _original = new CssValue(tokens);
            }

            public String CssText
            {
                get { return _value.CssString(); }
            }

            public CssValue Original
            {
                get { return _original; }
            }
        }
    }
}