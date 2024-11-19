var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Entities.Book, Dtos.Book>();
    cfg.CreateMap<Models.Book, Entities.Book>();
});
var mapper = configuration.CreateMapper();

// Entity'dan DTO yaratish:
var dto = mapper.Map<Dtos.Book>(entity); 