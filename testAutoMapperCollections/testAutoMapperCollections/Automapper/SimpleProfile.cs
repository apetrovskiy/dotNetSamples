namespace testAutoMapperCollections.Automapper
{
	using AutoMapper;
	using Types;

	public class SimpleProfile : Profile
	{
		public SimpleProfile()
		{
			this.CreateMap<Type01, Type02>()
				.ForMember(m => m.FloatData, n => n.MapFrom(k => k.DoubleData));
		}
	}
}