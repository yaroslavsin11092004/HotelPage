using Dto;
namespace Service
{
	public interface IGuestsService
	{
		public Task create_async(GuestsInputDto data);
		public Task<List<GuestsOutputDto>> read_all_async();
		public Task update_async(GuestsInputDto data);
		public Task delete_async(long id);
	}
}
