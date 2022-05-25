using CRMAplication;
using CRMApplication.Entities;

namespace CRMApplication.Repositories
{
    public class AddressTypeRepository: BaseRepository<AddressType>
    {
        public static AddressTypeRepository _Instance;
        public static AddressTypeRepository Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AddressTypeRepository();
                }
                return _Instance;
            }
            private set { }
        }
    }
}
