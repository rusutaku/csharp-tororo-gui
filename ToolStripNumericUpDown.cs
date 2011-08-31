using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

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
