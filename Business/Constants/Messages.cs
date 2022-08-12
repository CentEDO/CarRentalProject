using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi!";
        public static string CarDeleted = "Araba silindi!";
        public static string CarUpdated = "Araba güncellendi!";
        public static string CarNameInvalid = "Araba ismi geçersiz!";
        public static string CarsListed = "Araba(lar) listelendi";
        public static string CarIsNotHere = "Araba şu an başkasında";

        public static string MaintenanceTime = "Sistem bakımda!";

        public static string BrandAdded = "Marka eklendi!";
        public static string BrandNameInvalid = "Marka ismi geçersiz!";
        public static string BrandsListed = "Marka(lar) listelendi";
        public static string BrandUpdated = "Marka güncellendi!";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandLimitExceeded = "Marka sınırı aşıldı!";
       
        public static string ColorAdded = "Renk eklendi!";
        public static string ColorNameInvalid = "Renk ismi geçersiz!";
        public static string ColorListed = "Renk(ler) listelendi";
        public static string ColorUpdated = "Renk güncellendi!";
        public static string ColorDeleted = "Renk Silindi!";

        public static string UserAdded = "Kullanıcı eklendi!";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz!";
        public static string UsersListed = "Kullanıcı(lar) listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi!";
        public static string UserDeleted = "Kullanıcı silindi!";

        public static string RentalAdded = "Kiralama eklendi!";        
        public static string RentalListed = "Kiralama(lar) listelendi";
        public static string RentalUpdated = "Kiralama güncellendi!";
        public static string RentalDeleted = "Kiralama silindi!";

        public static string CarImageAdded = "Araba resmi eklendi!";
        public static string CarImageDeleted="Araba resmi silindi!";
        public static string CarImagesListed = "Araba resimleri listelendi!";
        public static string CarImageUpdated="Araba resmi güncellendi!";
        public static string ImageLimitofCarExceeded="Arabanın fazla resmi var!";
        public static string CarDoesNotExist = "Araba bulunamadı!";
    }
}
