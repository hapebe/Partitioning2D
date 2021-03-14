using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Persistence
{
    public interface ITabbedTextable
    {
        string TabbedTextHeaders();

        string ToTabbedText();

        void FromTabbedText(string s);
    }
}
