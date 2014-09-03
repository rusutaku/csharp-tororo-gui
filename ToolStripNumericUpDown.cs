using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace tororo_gui.Controls
{
    [ToolStripItemDesignerAvailability(
     ToolStripItemDesignerAvailability.ToolStrip |
     ToolStripItemDesignerAvailability.StatusStrip |
     ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripNumericUpDown : ToolStripControlHost
    {
        public ToolStripNumericUpDown()
            : base(new NumericUpDown())
        {

        }

        public NumericUpDown NumericUpDownControl
        {
            get
            {
                return Control as NumericUpDown;
            }
        }

    }
}
