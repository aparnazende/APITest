using System;
using System.Collections.Generic;
using System.Text;
using Services.Interface;
using ViewModel;
using System.Linq;
using DataAccessLayer.Repository;
using DataAccessLayer.Database;
using AutoMapper;

namespace Services.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IEntityBaseRepository<TAlbums> repo;
        private readonly IEntityBaseRepository<TSongs> songRepo;
        private readonly IEntityBaseRepository<TArtists> arRepo;
        private readonly IEntityBaseRepository<TCategory> caRepo;
        private readonly IEntityBaseRepository<TGenres> genRepo;
        private readonly IMapper _mapper;
        
        public AlbumService(IEntityBaseRepository<TAlbums> _repo, 
            IEntityBaseRepository<TSongs> _songRepo,
           IEntityBaseRepository<TArtists> _arRepo,
           IEntityBaseRepository<TCategory> _caRepo,
           IEntityBaseRepository<TGenres> _genRepo,
        IMapper mapper)
        {
            repo = _repo;
            songRepo = _songRepo;
            arRepo = _arRepo;
            caRepo = _caRepo;
            genRepo = _genRepo;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlbumDataViewModel AlbumDetails(int id)
        {
            try
            {
                var albumDetails = repo.GetAll().FirstOrDefault(a => a.Id == id);
                var songDetails = GetSongsViewModel(id);
                var album = _mapper.Map<AlbumViewModel>(albumDetails);
                var artist = GetArtistDetail(albumDetails?.ArtistId);
                var genre = GetGenreDetail(artist?.GenreId); 
                var category = GetCategoryDetail();// _mapper.Map<CategoryViewModel>(albumDetails?.Artist?.Genre?.Category);
                return new AlbumDataViewModel { Album = album, Artist = artist, Category = category, Genre = genre, Songs= songDetails };
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public ArtistViewModel GetArtistDetail(int? id=0)
        {
            try
            {
                var arttist = arRepo.GetAll().FirstOrDefault(a => a.GenreId == id);
                return _mapper.Map<ArtistViewModel>(arttist);
            }
            catch (Exception)
            {

                //throw;
            }
            return null;
        }
        public GenreViewModel GetGenreDetail(int? id = 0)
        {
            try
            {
                var genres = genRepo.GetAll().FirstOrDefault(a => a.CategoryId == id);
                return _mapper.Map<GenreViewModel>(genres);
            }
            catch (Exception)
            {

               // throw;
            }
            return null;
        }
        public CategoryViewModel GetCategoryDetail()
        {
            try
            {
                var category = caRepo.GetAll().FirstOrDefault();
                return _mapper.Map<CategoryViewModel>(category);
            }
            catch (Exception)
            {

               // throw;
            }
            return null;
        }
        public List<SongsViewModel> GetSongsViewModel(int? id)
        {
            try
            {
                var songDetails = (from s in songRepo.GetAll()
                                   where s.AlbumId == id
                                   select new SongsViewModel
                                   {
                                       Name = s.Name,
                                       Price = s.Price,
                                       Time = s.Time,
                                       SongRatings = s.TSongRatings.Where(i => i.SongId == s.Id).ToList(),
                                   }).ToList();
                return songDetails;
            }
            catch (Exception)
            {

              //  throw;
            }
            return null;
        }
    }
}
