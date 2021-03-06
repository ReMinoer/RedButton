﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    public partial class ColorDialogButton : UserControl
    {
        private readonly ColorDialog _dialog = new ColorDialog();
        private Color _color;

        public Color Color
        {
            get { return _color; }
            set
            {
                if (value == _color)
                    return;

                _color = value;
                _dialog.Color = value;

                button.BackColor = _color;
                label.Text = string.Format("{0}, {1}, {2}", _color.R, _color.G, _color.B);

                if (ColorChanged != null)
                    ColorChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler ColorChanged;

        public ColorDialogButton()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() != DialogResult.OK)
                return;

            Color = _dialog.Color;
        }
    }
}