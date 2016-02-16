using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModels.DragDrop
{
    public interface IDragable
    {
        Type DataType { get; }

        void Update(double x, double y);
    }
}
