using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S14L2.Models
{
    internal class CV
    {
        public InformazionePersonali informazionePersonali = new InformazionePersonali();
        public Studi studi = new Studi();
        public Impiego impiego = new Impiego();


        public void ImpostaInfomazioniPersonali()
        {
            Console.WriteLine("Ti verrano richiesti dei dati che verranno inseriti nel tuo CV");


            InserisciNome:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci Nome");
            string nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome))
            {
              informazionePersonali._nome = nome;  
            }
            else
            {
                goto InserisciNome;
            }
            
            InserisciCognome:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci Cognome");
            string cognome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(cognome))
            {
                informazionePersonali._cognome = cognome;
            }
            else 
            {
                goto InserisciCognome;
            }

            InserisciTelefono:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci numero di telefono");
            string telefono = Console.ReadLine();
            if (telefono.Length == 10)
            {
                informazionePersonali._telefono = telefono;
            }
            else
            {
                goto InserisciTelefono;
            }

            InserisciEmail:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci indirizzo email");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
            {
                informazionePersonali._email = email;
            }
            else
            {
                goto InserisciEmail;
            }

            ImpostaStudi();
        }

        public void ImpostaStudi()
        {
            InserisciQualifica:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci la tua qualifica");
            string qualifica = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(qualifica))
            {
                studi._qualifica = qualifica;
            }
            else
            {
                goto InserisciQualifica;
            }

            InserisciIstituto:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci nome istituto di qualifica");
            string istituto = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(istituto))
            {
                studi._istituto = istituto;
            }
            else
            {
                goto InserisciIstituto;
            }

            InserisciTipo:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci il tipo di istituto");
            string tipo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(istituto))
            {
                studi._tipo = tipo;
            }
            else
            {
                goto InserisciTipo;
            }

            InserisciDal:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci la data di inizio di frequenza dell'istituto");
            string dal = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dal) && DateTime.TryParse(dal, out DateTime dalData))
            {
                studi._dal = dalData;
            }
            else
            {
                goto InserisciDal;
            }

            InserisciAl:
            Console.WriteLine(" ");
            Console.WriteLine("Inserisci la data di fine di frequenza dell'istituto");
            string al = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(al) && DateTime.TryParse(al, out DateTime alData))
            {
                studi._al = alData;
            }
            else
            {
                goto InserisciAl;
            }

            ImpostaImpiego();
        }

        public void ImpostaImpiego()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Hai altre esperienze lavorative?");
            string response = Console.ReadLine();

            if (response.ToLower() == "no")
            {
                StampaDettagliCVSuSchermo();
            }
            else if (response.ToLower() == "si")
            {
                string azienda = GetInput("Inserisci azienda");
                string job = GetInput("Inserisci impiego");
                DateTime dalData = GetDateInput("Inserisci data di inizio del tuo impiego");
                DateTime? alData = GetOptionalDateInput("Inserisci data di fine del tuo impiego se concluso altrimenti lascia vuoto");
                string descrizione = GetInput("Descrivi il tuo lavoro");
                string compito = GetInput("Spiega nello specifico qual è il tuo compito");

                Esperienza newEsperienza = new Esperienza()
                {
                    _azienda = azienda,
                    _jobTitle = job,
                    _dal = dalData,
                    _al = alData,
                    _descrizione = descrizione,
                    _compiti = compito,
                };

                impiego.esperienza.Add(newEsperienza);
                ImpostaImpiego();
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Inserisci una risposta valida");
                ImpostaImpiego();
            }
        }

        private string GetInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private DateTime GetDateInput(string prompt)
        {
            DateTime date;
            string input;
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out date));

            return date;
        }

        private DateTime? GetOptionalDateInput(string prompt)
        {
            string input;
            DateTime? date = null;
            Console.WriteLine(" ");
            Console.WriteLine(prompt);
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && DateTime.TryParse(input, out DateTime result))
            {
                date = result;
            }

            return date;
        }


        public void StampaDettagliCVSuSchermo() 
        {
            Console.WriteLine(" ");
            foreach (var caz in impiego.esperienza)
            {
                Console.WriteLine(caz._azienda);
            }
        }
    }
}
