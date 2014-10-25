﻿namespace AngleSharp.DOM.Css
{
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-top
    /// </summary>
    sealed class CSSBorderTopProperty : CSSShorthandProperty, ICssBorderProperty
    {
        #region Fields

        readonly CSSBorderTopColorProperty _color;
        readonly CSSBorderTopStyleProperty _style;
        readonly CSSBorderTopWidthProperty _width;

        #endregion

        #region ctor

        internal CSSBorderTopProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderTop, rule, PropertyFlags.Animatable)
        {
            _color = Get<CSSBorderTopColorProperty>();
            _style = Get<CSSBorderTopStyleProperty>();
            _width = Get<CSSBorderTopWidthProperty>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the width of the given border property.
        /// </summary>
        public Length Width
        {
            get { return _width.Width; }
        }

        /// <summary>
        /// Gets the color of the given border property.
        /// </summary>
        public Color Color
        {
            get { return _color.Color; }
        }

        /// <summary>
        /// Gets the style of the given border property.
        /// </summary>
        public LineStyle Style
        {
            get { return _style.Style; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var list = value as CSSValueList ?? new CSSValueList(value);
            CSSValue width = null;
            CSSValue color = null;
            CSSValue style = null;

            if (list.Length > 3)
                return false;

            for (int i = 0; i < list.Length; i++)
            {
                if (!_width.CanStore(list[i], ref width) &&
                    !_color.CanStore(list[i], ref color) &&
                    !_style.CanStore(list[i], ref style))
                    return false;
            }

            return _width.TrySetValue(width) && _color.TrySetValue(color) && _style.TrySetValue(style);
        }

        #endregion
    }
}
