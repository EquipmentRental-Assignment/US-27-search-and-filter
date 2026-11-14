# US-27-search-and-filter
# US-70 – Söka och filtrera bokningar

## Beskrivning

Detta projekt är en del av min individuella inlämning i kursen Objektorienterad analys och design på Nackademin.

Syftet är att implementera och verifiera US-70 från gruppens bokningssystem för SXX Maskiner och Utrustning AB.

Applikationen är byggd i C#/.NET och används för att söka och filtrera befintliga bokningar.

## Funktioner

- Visa alla bokningar.
- Söka på bokningsnummer eller kundens e-postadress.
- Filtrera på tidigare och kommande bokningar.
- Filtrera på bokningsstatus.
- Kombinera sökning och filtrering.
- Visa ett meddelande när inga bokningar hittas.

## Projektstruktur

- Models – Innehåller Booking, Customer och enums.
- Interface – Innehåller interfaces för service och repository.
- Repository – Hanterar lagring av bokningar i minnet.
- Service – Innehåller logiken för sökning och filtrering.
- Presentation – Innehåller BookingView med konsolmenyn.
- Program.cs – Skapar testdata och startar applikationen.

## Starta applikationen

1. Klona eller ladda ner projektet från GitHub.
2. Öppna projektet i Visual Studio.
3. Starta konsolapplikationen med Ctrl + F5.
4. Välj ett alternativ i menyn för att köra ett test.

Du behöver .NET SDK som stöds av projektets target framework.

## Testmeny

| Val | Funktion |
|---|---|
| 1 | Visa alla bokningar |
| 2 | Testa sökning på e-post |
| 3 | Testa sökning på bokningsnummer |
| 4 | Testa kommande bokningar |
| 5 | Testa filtrering på status |
| 6 | Alternativt flöde A1 – Inga bokningar hittas |
| 7 | Alternativt flöde A2 – Inga bokningar efter filtrering |
| 0 | Avsluta programmet |

Testerna använder fördefinierade bokningar och sökvärden. Användaren behöver därför inte skriva in några egna söktermer.

## Verifiering

### Huvudflöde

Välj alternativ 2 för att söka på en befintlig e-postadress.

Förväntat resultat: Systemet visar de bokningar som tillhör e-postadressen.

### Alternativt flöde A1

Välj alternativ 6 för att söka på en e-postadress som inte finns.

Förväntat resultat: Systemet visar "No bookings found."

### Alternativt flöde A2

Välj alternativ 7 för att kombinera sökning och filtrering utan matchande resultat.

Förväntat resultat: Systemet visar "No bookings found."

## Avgränsningar

Applikationen är skapad för att verifiera sökning och filtrering. Den innehåller därför ingen inloggning, databas eller funktion för att skapa och ändra bokningar via användargränssnittet.

Bokningarna sparas tillfälligt i minnet och försvinner när programmet avslutas.

## UML-diagram

Aktivitetsdiagram och sekvensdiagram för US-70 finns i den individuella inlämningsrapporten.
