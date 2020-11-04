using Doljniki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doljniki.ViewModel.Interfaces
{
    public interface IFileService
    {
        List<Doljnik> Open(string filename);
        void Save(string filename, List<Doljnik> doljnikList);
    }
}
