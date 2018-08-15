using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Interfaces
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
