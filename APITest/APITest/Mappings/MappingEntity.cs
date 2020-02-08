using AutoMapper;
using DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace APITest.Mappings
{
    public class MappingEntity : Profile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MappingEntity()
        {
            CreateMap<AlbumRatingViewModel, TAlbumRatings>().ReverseMap();
            CreateMap<AlbumViewModel, TAlbums>().ReverseMap();
            CreateMap<ArtistViewModel, TArtists>().ReverseMap();
            CreateMap<CategoryViewModel, TCategory>().ReverseMap();
            CreateMap<GenreViewModel, TGenres>().ReverseMap();
            CreateMap<SongsRatingViewModel, TSongRatings>().ReverseMap();
            CreateMap<SongsViewModel, TSongs>().ReverseMap();
        }
    }
}
