

namespace AccountingSystemForWindowsFormLast.Helpers
{
    public enum Accent
    {
        Primary,
        Success,
        Danger,
        Warning,
        Neutral
    }

    /// <summary>
    /// مصدر واحد للألوان والخطوط وتنسيق الأدوات في كل واجهات البرنامج لضمان التناسق
    /// بين الشاشات، مع دعم التكبير والتصغير (DPI) واتجاه من اليمين لليسار.
    /// </summary>
    public static class UiTheme
    {
        public static readonly Color Primary = Color.FromArgb(24, 78, 58);
        public static readonly Color PrimaryLight = Color.FromArgb(35, 120, 75);
        public static readonly Color AccentGold = Color.FromArgb(214, 170, 54);
        public static readonly Color Surface = Color.FromArgb(246, 248, 247);
        public static readonly Color SurfaceAlt = Color.FromArgb(238, 244, 241);
        public static readonly Color Border = Color.FromArgb(203, 215, 209);
        public static readonly Color TextDark = Color.FromArgb(45, 55, 50);
        public static readonly Color TextMuted = Color.FromArgb(105, 118, 112);
        public static readonly Color Danger = Color.FromArgb(178, 62, 54);
        public static readonly Color Success = Color.FromArgb(46, 125, 50);
        public static readonly Color Warning = Color.FromArgb(191, 143, 0);

        private const string FontFamily = "Segoe UI";
        private const int InputHeight = 30;
        private const int RowHeight = 32;
        private const int HeaderHeight = 34;

        public static Font Body(float size = 10F)
        {
            return new Font(FontFamily, size, FontStyle.Regular, GraphicsUnit.Point);
        }

        public static Font Bold(float size = 10F)
        {
            return new Font(FontFamily, size, FontStyle.Bold, GraphicsUnit.Point);
        }

        /// <summary>
        /// يطبّق الهوية البصرية على النموذج وكل أدواته، ويحوّل الحقول إلى تخطيط مرن
        /// يتمدد مع النافذة دون أن تتداخل الأدوات أو تُقتطع.
        /// </summary>
        public static void Apply(Form form)
        {
            if (form == null)
                return;

            form.Font = Body(10F);
            form.BackColor = Surface;
            form.RightToLeft = RightToLeft.Yes;
            form.RightToLeftLayout = true;
            form.KeyPreview = true;
            SetDoubleBuffered(form);

            foreach (Control control in form.Controls)
            {
                Apply(control);
            }
        }

        public static void Apply(Control control)
        {
            if (control == null)
                return;

            switch (control)
            {
                case Button button:
                    StyleButton(button);
                    break;

                case TextBoxBase textBox:
                    StyleInput(textBox);
                    break;

                case ComboBox comboBox:
                    StyleInput(comboBox);
                    break;

                case DateTimePicker dateTimePicker:
                    StyleInput(dateTimePicker);
                    break;

                case NumericUpDown numericUpDown:
                    StyleInput(numericUpDown);
                    break;

                case DataGridView grid:
                    StyleGrid(grid);
                    break;

                case TableLayoutPanel table:
                    table.BackColor = Surface;
                    table.RightToLeft = RightToLeft.Yes;
                    break;

                case GroupBox groupBox:
                    groupBox.Font = Bold(10F);
                    groupBox.ForeColor = Primary;
                    groupBox.BackColor = Surface;
                    groupBox.Padding = new Padding(12, 8, 12, 10);
                    break;

                case Label label:
                    StyleLabel(label);
                    break;

                case Panel panel:
                    StylePanel(panel);
                    break;

                case MenuStrip menu:
                    StyleMenu(menu);
                    break;

                case StatusStrip status:
                    status.BackColor = Surface;
                    status.Font = Body(9F);
                    status.ForeColor = TextMuted;
                    break;

                case ToolStrip toolStrip:
                    toolStrip.BackColor = SurfaceAlt;
                    toolStrip.Font = Body(10F);
                    break;
                    
            }

            foreach (Control child in control.Controls)
            {   
                Apply(child);

            }
            if ((control.Name == "panelHeader" || control.Name == "pnlHeader") && control.Controls[0] is Label)
            {
                control.Controls[0].ForeColor = Color.White;
             


            }

          

        }

        private static void StylePanel(Panel panel)
        {
            if (panel.BackColor == Primary || panel.BackColor == PrimaryLight)
            {
                foreach (Control child in panel.Controls)
                {
                    if (child is Label label && label.ForeColor != Color.White)
                        label.ForeColor = Color.White;
                }

                return;
            }

            panel.BackColor = Surface;
            panel.Font = Body(10F);
        }

        private static void StyleLabel(Label label)
        {
            float currentSize = label.Font?.Size ?? 10F;
            bool isBold = label.Font?.Bold ?? false;
            bool isTitle = currentSize >= 14F;

            label.Font = isTitle ? Bold(currentSize) : Body(currentSize);
            label.ForeColor = isTitle ? label.ForeColor : TextDark;

            if (label.AutoSize && label.TextAlign == ContentAlignment.TopLeft)
                label.TextAlign = ContentAlignment.MiddleRight;

            if (!isTitle && string.IsNullOrWhiteSpace(label.Text))
                label.Visible = false;
        }

        private static void StyleInput(Control input)
        {
            input.Font = Body(10F);
            input.BackColor = Color.White;
            input.ForeColor = TextDark;
            input.Margin = new Padding(6, 6, 6, 6);
            input.Anchor = AnchorStyles.Right | AnchorStyles.Left;

            if (input is TextBoxBase textBoxBase)
                textBoxBase.BorderStyle = BorderStyle.FixedSingle;

            if (input is ComboBox comboBox && comboBox.FlatStyle == FlatStyle.System)
                comboBox.FlatStyle = FlatStyle.Standard;

            if (input.Height < InputHeight)
                input.Height = InputHeight;
        }

        public static void StyleButton(Button button, Accent accent)
        {
            if (button == null)
                return;

            button.FlatStyle = FlatStyle.Flat;
            button.Font = Bold(10F);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.Margin = new Padding(6);
            button.AutoSize = false;

            Color background;
            Color foreground;

            switch (accent)
            {
                case Accent.Primary:
                    background = Primary;
                    foreground = Color.White;
                    break;

                case Accent.Success:
                    background = Success;
                    foreground = Color.White;
                    break;

                case Accent.Danger:
                    background = Danger;
                    foreground = Color.White;
                    break;

                case Accent.Warning:
                    background = Warning;
                    foreground = Color.White;
                    break;

                default:
                    background = Color.White;
                    foreground = Primary;
                    break;
            }

            button.BackColor = background;
            button.ForeColor = foreground;
            button.FlatAppearance.BorderColor = accent == Accent.Neutral ? Primary : background;
            button.FlatAppearance.BorderSize = accent == Accent.Neutral ? 1 : 0;
            button.FlatAppearance.MouseOverBackColor = Lighten(background, 0.12F);
            button.FlatAppearance.MouseDownBackColor = Lighten(background, -0.12F);
        }

        private static void StyleButton(Button button)
        {
            if (button == null)
                return;

            Accent accent = Accent.Primary;
            bool alreadyThemed = button.FlatStyle == FlatStyle.Flat && button.FlatAppearance.BorderSize >= 0
                && button.Cursor == Cursors.Hand;

            if (button.ForeColor == Color.White)
            {
                accent = button.BackColor == Danger
                    ? Accent.Danger
                    : button.BackColor == Warning
                        ? Accent.Warning
                        : button.BackColor == Success
                            ? Accent.Success
                            : Accent.Primary;
            }
            else if (!alreadyThemed)
            {
                accent = Accent.Primary;
            }
            else
            {
                accent = Accent.Neutral;
            }

            StyleButton(button, accent);

            if (accent == Accent.Neutral)
                button.ForeColor = Primary;
        }

        public static void StyleGrid(DataGridView grid)
        {
            if (grid == null)
                return;

            grid.Font = Body(10F);
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = HeaderHeight;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Border;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToResizeRows = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryLight;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = Bold(10F);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryLight;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6);

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = TextDark;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 232, 222);
            grid.DefaultCellStyle.SelectionForeColor = TextDark;
            grid.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            grid.AlternatingRowsDefaultCellStyle.BackColor = SurfaceAlt;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 232, 222);

            grid.RowTemplate.Height = RowHeight;



            grid.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

             grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grid.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;

            grid.GridColor = Color.LightGray;
        }

        private static void StyleMenu(MenuStrip menu)
        {
            menu.BackColor = Color.White;
            menu.ForeColor = TextDark;
            menu.Font = Body(10F);
            menu.RightToLeft = RightToLeft.Yes;
            menu.Padding = new Padding(12, 6, 12, 6);
            menu.RenderMode = ToolStripRenderMode.System;

            foreach (ToolStripItem item in menu.Items)
            {
                StyleMenuItem(item);
            }
        }

        private static void StyleMenuItem(ToolStripItem item)
        {
            if (item == null)
                return;

            item.BackColor = Color.White;
            item.ForeColor = TextDark;
            item.Font = Body(10F);
            item.AutoSize = true;
            item.Padding = new Padding(8, 4, 8, 4);
            item.Margin = new Padding(1, 0, 1, 0);

            if (item is ToolStripDropDownItem dropDownItem)
            {
                foreach (ToolStripItem child in dropDownItem.DropDownItems)
                {
                    StyleMenuItem(child);
                }
            }
        }

        /// <summary>
        /// يقلّل وميض الرسم في الحاويات (خاصية محمية في WinForms، لذلك تُستخدم الانعكاس).
        /// </summary>
        private static void SetDoubleBuffered(Control control)
        {
            try
            {
                typeof(Control)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    ?.SetValue(control, true);
            }
            catch
            {
                // تجاهل: خاصية تحسين اختيارية
            }
        }

        public static Color Lighten(Color color, float amount)
        {
            int red = (int)Math.Clamp(color.R + (255 - color.R) * amount, 0, 255);
            int green = (int)Math.Clamp(color.G + (255 - color.G) * amount, 0, 255);
            int blue = (int)Math.Clamp(color.B + (255 - color.B) * amount, 0, 255);
            return Color.FromArgb(red, green, blue);
        }
    }
}
