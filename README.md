Web shop Muchos motors je web aplikacija za naručivanje auto-dijelova i termina. Osim pomenutih funkcionalnosti ova aplikacija zaposlenicima Muchos Motors-a služi za uvid u rad kompanije. U mogućnosti su pregledati narudžbe, evidentirati ih i kreirati fakture na osnovu njih, evidentirati nove autodijelovi i voditi brigu o trenutnom stanju unesenih autodijelova i inventaru. 

Opće funkcionalnosti
Kreiranje narudžbe
Korisnik je u mogućnosti da odabire određene auto proizvode koji ga zanimaju i dodaje ih u korpu. Nakon što korisnik odluči da zaključi narudžbu, iz stranice „Korpa“ nastavlja proces kupovine odabirom opcije „Nastavi kupovinu“ gdje ga aplikacija odvodi na formu u koju korisnik unosi svoje lične podatke u svrhu dostave narudžbe. Ukoliko je prijavljen, polja će se automatski ispuniti njegovim ličnim podacima sa kreiranog profila. U mogućnosti je da ih modifikuje po želji ukoliko se ne slažu sa njegovim uslovima narudžbe. Nakon toga, klikom na „Naruči“, narudžba je kreirana. 

Evidencija narudžbi
Nakon što je korisnik kreirao narudžbu, u listu narudžbi se dodaje i prethodno kreirana. Pod evidencijom narudžbe podrazumjeva se ažuriranje stavki kao što je vrijeme isporuke, spašavanje informacije o radniku koji je evidentirao narudžbu te snimanje datuma kreiranja fakture. Nakon što korisnik odabere datum pošiljke i odabere opciju „Evidentiraj narudžbu“, kreira se faktura za odabranu narudžbu.

Evidencija inventara
Ukoliko korisnik želi da unese određene proizvode na stanju, na rasploganju mu je opcija „Evidencija inventara“ > „Kreiraj novi unos“. Korisniku se otvara nova stranica sa formom u kojoj se korisniku nudi „drop-down“ menu gdje može odabrati auto dio kojeg unose u inventar i polje za unos količine unosa. Kada korisnik unese tražene podatke, sve izmjene snima klikom na „Kreiraj novi unos“. 

Evidencija auto-dijelova
Ukoliko ne postoje informacija o dijelu kojeg je korisnik pokušao unijeti preko funkcionalnosti „Evidencija inventara“, potrebno je da prije unosa dijela u inventar, uvede traženi dio preko funkcionalnosti: „Evidencija auto-dijelova“. Korisniku se odabirom te funkcionalnosti pruža mogućnost unosa naziva auto dijela, šifre, prodajne cijene, kupovne cijene, detalja i ostalih relevantnih informacija vezanih za auto dio. Korisnik je prilikom pregleda postojećih auto-dijelova u mogućnosti da ažurira ili izbriše uneseni dio klikom na „Detalji“ ili „Izbriši“ dugme.

Paging 
Paging je implementiran samo za entitete za koje se pretpostavlja da će predstavljati veliki skup u bazi podataka. U našem slučaju su to: auto-dijelovi (car-parts) i narudžbe (orders). Prilikom dohvatanja auto-dijelova u servisnoj metodi se prvo gleda da li je proslijeđen filter model koji u sebi ima dva flag-a: jedan za brendove za koji auto-dijelovi odgovoraju, drugi za modele auta za koji auto-dijelovi odgovoraju. Nakon filtriranja podataka iz IQuearable objekta se na osnovu parametara „pageSize“ i „page“ kreira PagedResult objekat u kojem se nalazi tačno onoliko podataka koliko je korisnik tražio. Na front-endu, korisnik u donjem dijelu stranice za pregled autodijelova i narudžbi može da klikom odredi koju stranicu će mu sljedeću učitati i sa koliko podataka će biti ispunjena. Korištena je gotova verzija komponente pod nazivom „mat-paginator“.

Continious integration
Kod za kontinuiranu integraciju se nalazi u azure-pipelines.yml file-u. Ono što nisam uspio jeste da ukoliko se desi promjena na bazi, pipeline neće izvršiti potrebne migracije. Takođe nakon izvršenog pipeline-a web.config se treba ažurirati da bi se metode PUT i DELETE mogle neometano izvršavati po potrebi. Ukoliko možemo zanemariti pomenute probleme, izmjene na backendu i frontendu se uredno izvršavaju uz povremenu grešku prilikom transfera fajlova na host-a uz pomoć FTP protokola. 

Reporti sa parametrima
Implementirani uz pomoć Quest PDF biblioteke. Problem sa njom jeste što nisam uspio da generišem putanju fajl sistema na kojoj će se faktura kreirati. Te se u oba slučaja tj. lokalno pokrenute aplikacije ili hostane aplikacije generiše na putanji aplikacije. Lokalno generisanom fajlu se može pristupiti i otvoriti report dok se na hostanoj aplikaciji dokumentu može pristupiti preko Pleska ali se ne može otvoriti i prikazati. 

Exception handling
Implementiran uz pomoć globalnog exception middleware-a, gdje on prilikom svake greške koja se desi na aplikaciji kreira custom response a front dio prikaže tu istu grešku ukoliko se desi. 
Aplikacija razlikuje dvije vrste grešaka. Greške koje aplikacija „uhvati“ te na osnovu njih kreira i „baci“ novi exception nazvan AppException, te greške koje nisu uhvaćene 
Front dio prikazivanja modala greške je implementiran za login vezane pogreške dok se u bazu upisuju greške koje ne moraju biti nužno povezane sa login kredencijalima. Na primjer, upisuje se greška ukoliko korisnik pokuša pristupiti auto-dijelu koji ne postoji. 

Repository pattern
Implementiran za sve entitete koje aplikacija dobija iz baze podataka. Za svaki od entiteta implementirane su klasične repository metode kao što su: GetAll, GetById, Create, Update, Delete.

Organizacija koda u zasebne komponente ( Backend / Frontend)
Organizacijom koda pokušalo se pratiti MVC pattern arhitekture gdje su modeli, servisi i kontroleri odvojeni u zaseban folder. Servisi se međusobno mogu pozivati te je time smanjeno ponavljanje koda.  Pojedine Helper klase kao što je ValidationUtils koja validira podatke, korištene su na raznim mjestima kroz aplikaciju.
Na nivou front-enda komponente kao što su app-paginator, navigation header komponenta koje se zajedno sa pojedinim front end servisima koriste na više mjesta po potrebi.

Upload i prikaz slika
Implementiran uz pomoć vježbi sa predmeta. Korišten je FileReader za review slike koji konvertuje slike iz base64 formata u njemu pogodan file. Prilikom snimanja fajla, na API strani, slike se iz base64 formata konvertuje u bite-ove te se snima na određenu lokaciju u file sistemu. Slika se ne prikazuje na modalu autodijelova ali se prikazuje na početnoj stranici aplikacije. Kada se slika dohvata, potreban je samo validan url link pomoću kojeg se cilja na traženu putanju. Slika se prikazuje uz pomoć src atributa.
