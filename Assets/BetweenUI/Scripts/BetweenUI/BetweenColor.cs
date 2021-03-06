﻿namespace Assets.BetweenUI.Scripts.BetweenUI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Transition graphic color.
    /// </summary>
    [RequireComponent(typeof(Graphic))]
    [AddComponentMenu("BetweenUI/Between Color")]
    public class BetweenColor : BetweenBase
    {
        public Color From = Color.white;
        public Color To = Color.white;

        private Graphic graphic;

        /// <summary>
        /// Transit's current value.
        /// </summary>

        public Color Value
        {
            get
            {
                if (this.graphic == null)
                {
                    this.graphic = this.GetComponent<Graphic>();
                }

                return this.graphic.color;
            }
            set
            {
                if (this.graphic == null)
                {
                    this.graphic = this.GetComponent<Graphic>();
                }

                this.graphic.color = value;
            }
        }

        /// <summary>
        /// Transition the value.
        /// </summary>

        protected override void OnUpdate(float factor)
        {
            this.Value = Color.Lerp(this.From, this.To, factor);
        }

        public void Reset()
        {
            ToForCurrent();
            FromForCurrent();
        }

        [ContextMenu("Current color for To")]
        public void ToForCurrent()
        {
            this.To = this.GetComponent<Graphic>().color;
        }

        [ContextMenu("Current color for From")]
        public void FromForCurrent()
        {
            this.From = this.GetComponent<Graphic>().color;
        }
    }
}
