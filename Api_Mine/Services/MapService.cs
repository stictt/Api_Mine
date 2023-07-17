using Api_Mine.Models.API_Data_Model;
using Api_Mine.Models.Data_Access;
using AutoMapper;
using AutoMapper.Execution;
using System.Linq.Expressions;

namespace Api_Mine.Services
{
    public class MapService
    {
        public Toutput MapBase<Tinput,Toutput>(Tinput input)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tinput, Toutput>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<Toutput>(input);
        }

        public DrillBlockPointsDatabaseModel MapDrillBlockPointsDatabaseModel(EditDrillBlockPointsDTO editDrillBlockPointsDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditDrillBlockPointsDTO, DrillBlockPointsDatabaseModel>()
                        .ForMember(x => x.Sequence,
                            y => y.MapFrom(s => s.Sequence));
                cfg.CreateMap<PointDTO, PointDatabaseModel>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<DrillBlockPointsDatabaseModel>(editDrillBlockPointsDTO);
        }

        public DrillBlockPointsDTO MapDrillBlockPointsDTO(DrillBlockPointsDatabaseModel databaseModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DrillBlockPointsDatabaseModel, DrillBlockPointsDTO>()
                        .ForMember(x => x.Sequence,
                            y => y.MapFrom(s => s.Sequence));
                cfg.CreateMap<PointDatabaseModel, PointDTO>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<DrillBlockPointsDTO>(databaseModel);
        }

    }
}
