using AutoMapper;
using DataAccessLayer.Database;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Service;
using System;
using ViewModel;
using Xunit;
namespace UnitTestProject
{
    public class UnitTest1
    {

        private readonly IEntityBaseRepository<TAlbums> repo;
        private readonly IEntityBaseRepository<TSongs> songRepo;
        private readonly IEntityBaseRepository<TArtists> arRepo;
        private readonly IEntityBaseRepository<TCategory> caRepo;
        private readonly IEntityBaseRepository<TGenres> genRepo;
        private readonly IMapper _mapper;
        private IAlbumService albumService;
        protected IDbFactory _DbFactory;

        public UnitTest1()
        {

            _DbFactory = new DbFactory();
            repo = new EntityBaseRepository<TAlbums>(_DbFactory);
            songRepo = new EntityBaseRepository<TSongs>(_DbFactory);
            arRepo = new EntityBaseRepository<TArtists>(_DbFactory);
            caRepo = new EntityBaseRepository<TCategory>(_DbFactory);
            genRepo = new EntityBaseRepository<TGenres>(_DbFactory);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AlbumViewModel, TAlbums>().ReverseMap();
                cfg.CreateMap<ArtistViewModel, TArtists>().ReverseMap();
                cfg.CreateMap<CategoryViewModel, TCategory>().ReverseMap();
                cfg.CreateMap<GenreViewModel, TGenres>().ReverseMap();
                cfg.CreateMap<SongsRatingViewModel, TSongRatings>().ReverseMap();
                cfg.CreateMap<SongsViewModel, TSongs>().ReverseMap();
            });
            _mapper = config.CreateMapper();

        }
        [Fact]
        public void GetAlbum_MatchResult()
        {
            //Arrange  
            albumService = new AlbumService(repo, songRepo, arRepo, caRepo, genRepo, _mapper);
            var albumId = 1;
            //Act  
            var data = albumService.AlbumDetails(albumId);
            //Assert              
            Assert.Equal("TestTestTest", data.Album.Name);
            Assert.Equal("1.00", Convert.ToString(data.Album.Price));
        }
        [Fact]
        public void GetAlbum_NotFoundResult()
        {
            //Arrange  
            albumService = new AlbumService(repo, songRepo, arRepo, caRepo, genRepo, _mapper);
            var albumId = 2;
            //Act  
            var data = albumService.AlbumDetails(albumId);
            //Assert              
            Assert.Null(data.Album);
            Assert.Null(data.Artist);
            Assert.NotNull(data.Category);
            Assert.Null(data.Genre);

        }
    }
}
