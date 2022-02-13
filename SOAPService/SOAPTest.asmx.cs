using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAPService
{
    /// <summary>
    /// Opis podsumowujący dla SOAPTest
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    [System.Web.Script.Services.ScriptService]
    public class SOAPTest : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Witaj świecie";
        }

        [WebMethod]
        public bool AddCardToDatabase(string cardId, string cardName, string cmc, string type, string subTypes, int power, int toughness, string cardText, string rarity)
        {
               

            using (CardsDB cardsDB = new CardsDB())
            {
                var queryResult = cardsDB.CardsTable.Find(cardId);

                if(queryResult != null)
                {
                    return false;
                }

                CardsTable cardsTable = new CardsTable()
                {
                    cardId = cardId,
                    cardName = cardName,
                    cmc = cmc,  
                    type = type,
                    subTypes = subTypes,
                    powerValue = power,
                    toughness = toughness,
                    cardText = cardText,
                    rarity = rarity
                };


                cardsDB.CardsTable.Add(cardsTable);
                cardsDB.SaveChanges();
            }

            return true;
        }

        [WebMethod]
        public CardsTable FindCard(string cardId)
        {
            CardsTable cardsTable = new CardsTable();

            using (CardsDB cardsDB = new CardsDB())
            {
                var queryResult = cardsDB.CardsTable.Find(cardId);

                if(queryResult != null)
                {
                    cardsTable = queryResult;
                }   
            }

            return cardsTable;
        }

        [WebMethod]
        public bool DeleteCard(string cardId)
        {
            CardsTable cardsTable = new CardsTable();

            using (CardsDB cardsDB = new CardsDB())
            {
                var queryResult = cardsDB.CardsTable.Find(cardId);

                if (queryResult == null)
                {
                    return false;
                }

                cardsDB.CardsTable.Remove(queryResult);
                cardsDB.SaveChanges();
            }

            return true;
        }
    }
}
