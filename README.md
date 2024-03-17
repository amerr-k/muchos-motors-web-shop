#Web Shop Muchos Motors
Web shop Muchos Motors je web aplikacija za naručivanje auto-dijelova i termina. Osim navedenih funkcionalnosti, ova aplikacija omogućava zaposlenicima Muchos Motors-a uvid u rad kompanije. Oni mogu pregledati narudžbe, evidentirati ih, kreirati fakture na osnovu njih, evidentirati nove auto-dijelove i voditi brigu o trenutnom stanju unesenih auto-dijelova i inventara.

##Opće funkcionalnosti
Kreiranje narudžbe
Korisnik može odabrati određene auto proizvode i dodati ih u korpu. Nakon što korisnik odluči da zaključi narudžbu, nastavlja proces kupovine odabirom opcije "Nastavi kupovinu", gdje unosi svoje lične podatke za dostavu narudžbe. Ukoliko je prijavljen, polja će se automatski popuniti njegovim ličnim podacima. Korisnik može modifikovati ove podatke prije potvrde narudžbe.

##Evidencija narudžbi
Nakon kreiranja narudžbe, ona se dodaje u listu narudžbi. Evidencija narudžbi uključuje ažuriranje stavki poput vremena isporuke, informacija o radniku koji je evidentirao narudžbu i datuma kreiranja fakture. Kada korisnik odabere datum pošiljke i opciju "Evidentiraj narudžbu", kreira se faktura za odabranu narudžbu.

##Evidencija inventara
Korisnik može unijeti određene proizvode na stanje kroz opciju "Evidencija inventara" > "Kreiraj novi unos". Korisniku se otvara forma gdje odabire auto dio koji unosi u inventar i unosi količinu unosa. Nakon unosa, sve izmjene se snimaju.

##Evidencija auto-dijelova
Prije unosa dijela u inventar, korisnik treba unijeti traženi dio preko opcije "Evidencija auto-dijelova". Korisnik unosi naziv auto dijela, šifru, prodajnu cijenu, kupovnu cijenu, detalje i ostale relevantne informacije. Korisnik može ažurirati ili izbrisati uneseni dio.

##Paging
Paging je implementiran za entitete koji predstavljaju veliki skup u bazi podataka: auto-dijelovi i narudžbe. Korisnik može odabrati stranicu za pregled i broj prikazanih podataka.

##Kontinuirana integracija
Kod za kontinuiranu integraciju se nalazi u azure-pipelines.yml file-u. Potrebno je ažurirati web.config nakon izvršenog pipeline-a. Izmjene na backendu i frontendu se uredno izvršavaju uz povremene greške prilikom transfera fajlova na host uz pomoć FTP protokola.

##Izvještaji sa parametrima
Implementirani su uz pomoć Quest PDF biblioteke. Faktura se generiše na putanji aplikacije.

##Obrada grešaka
Implementirana je globalna obrada grešaka, koja kreira custom response prilikom greške. Frontend prikazuje grešku ukoliko se desi. Aplikacija razlikuje greške koje su uhvaćene i one koje nisu. Na frontendu je implementiran prikaz modala greške za login vezane greške.

##Repository pattern
Implementiran je za sve entitete koje aplikacija dobija iz baze podataka. Za svaki entitet su implementirane klasične repository metode.

##Organizacija koda
Kod je organiziran po MVC arhitekturi. Servisi su odvojeni u zaseban folder radi smanjenja ponavljanja koda. Helper klase kao što je ValidationUtils su korištene na raznim mjestima kroz aplikaciju.

##Upload i prikaz slika
Implementiran je uz pomoć FileReader-a za review slike koji konvertuje slike iz base64 formata u file. Slike se snimaju na određenu lokaciju u file sistemu. Slika se prikazuje na početnoj stranici aplikacije putem src atributa.
