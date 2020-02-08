using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Interface
{
   public interface IAlbumService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AlbumDataViewModel AlbumDetails(int id);
    }
}
