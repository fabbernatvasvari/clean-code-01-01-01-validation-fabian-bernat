# 🎓 OOP Tananyag – Validáció a Model rétegben (.NET Console példa)

## 🎯 Cél

Ebben a tananyagban megtanuljuk, hogyan valósítható meg **objektumorientált programozásban (OOP)** az **adatok érvényességének biztosítása** (validáció) **külön rétegbe szervezve**, ipari szemléletben, mégis érthetően.

A példában egy egyszerű **Customer (ügyfél)** osztályt használunk, amelyet egy **Validator** ellenőriz.  
Ha a bevitt adatok érvénytelenek, a program **kivételt dob**, ezzel megakadályozva a hibás objektum létrehozását.

---

## 🧱 Projekt szerkezete

```
Downloads/
├─ Model/
│  └─ Customer.cs
├─ Common/
│  ├─ Validator.cs
│  └─ ErrorMessages.cs
└─ Exception/
   └─ ValidationException.cs
```

---

## 👤 1. Customer.cs – Az entitás (modell)

### 🧩 Szerepe

A **Customer** osztály egy ügyfelet ír le: névvel, e-mail címmel és egyenleggel.  
Fontos, hogy csak **érvényes állapotban** jöhessen létre, ezért a konstruktorban rögtön **validáljuk** az adatokat.

### 🧠 Kulcsfogalmak

- **Property + private set:** az érték kívülről nem módosítható.
- **Konstruktor validálás:** a hibás adatokat már létrehozáskor kiszűrjük.
- **Trim:** felesleges szóközök eltávolítása.

### 📘 Kódrészlet

```csharp
public sealed class Customer
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public decimal Amount { get; private set; }

    public Customer(string name, string email, decimal amount)
    {
        Validator.Validate(name, email, amount);
        Name = name.Trim();
        Email = email.Trim();
        Amount = amount;
    }

    public override string ToString() => $"{Name} <{Email}> (Egyenleg: {Amount} Ft)";
}
```

### 💬 Magyarázat

1. A `Validator.Validate()` gondoskodik róla, hogy minden adat helyes legyen.
2. Ha bármelyik adat hibás (pl. túl rövid név, érvénytelen e-mail, negatív összeg), **kivételt** dob.
3. Így a programban **nem létezhet hibás állapotú ügyfél** – ez a domain modellek egyik alapszabálya.

---

## 🧮 2. Validator.cs – A szabályok őre

### 🧩 Szerepe

A `Validator` osztály végzi az ellenőrzést:

- minden egyes mezőre külön metódus van (SRP – *Single Responsibility Principle*),
- valamint egy teljes objektumot is tud ellenőrizni.

### 🧠 Kulcsfogalmak

- **Statikus osztály:** közös segéd, nem kell példányosítani.
- **Túlterhelés:** ugyanaz a metódus többféle paraméterezéssel hívható (`Validate(name,email,amount)` és `Validate(Customer)`).
- **Kivétel dobása:** ha valami érvénytelen, a validátor `ValidationException`-t dob.

### 📘 Kódrészlet (rövidített)

```csharp
public static class Validator
{
    public static void Validate(Customer customer)
    {
        if (customer == null)
            throw new ValidationException(ErrorMessages.ObjectNull);

        Validate(customer.Name, customer.Email, customer.Amount);
    }

    public static void Validate(string name, string email, decimal amount)
    {
        ValidateName(name);
        ValidateEmail(email);
        ValidateAmount(amount);
    }
}
```

### 💬 Magyarázat

- **`Validate(Customer)`**: az egész objektumot vizsgálja.
- **`Validate(name, email, amount)`**: a konstruktorban hívható, mielőtt az objektum létrejön.
- **SRP:** minden metódus csak egy dolgot ellenőriz (jó tiszta kód gyakorlat).

### 🔍 Részmetódusok röviden

#### `ValidateName(string name)`

- null vagy üres → hiba
- rövidebb mint 2 karakter → hiba
- csak betű, szóköz, kötőjel megengedett

#### `ValidateEmail(string email)`

- üres vagy hiányzik `@` → hiba
- egyszerű, oktatási célú ellenőrzés

#### `ValidateAmount(decimal amount)`

- negatív → hiba
- túl nagy összeg (1 000 000 felett) → hiba

---

## ⚠️ 3. ValidationException.cs – Hibák kezelése

### 🧩 Szerepe

Ha bármelyik validálás sikertelen, **ezt a kivételt dobjuk**.  
A cél, hogy a hibát ne csak “visszaadjuk”, hanem megszakítsuk a hibás folyamatot.

### 📘 Kódrészlet

```csharp
public sealed class ValidationException : System.Exception
{
    public ValidationException(string message) : base(message) { }
}
```

### 💬 Magyarázat

- A .NET `Exception` osztályát örökli.
- Csak egy `message` paramétert vár – ennyi elég a tanuló szintjén.
- A `Validator` mindig ezt dobja, ha szabályt sért valami.

---

## 💬 4. ErrorMessages.cs – Hibaüzenetek központosítása

### 🧩 Szerepe

Az összes hibaüzenetet **egy helyen** tartjuk, így könnyen karbantartható és lokalizálható.

### 📘 Kódrészlet

```csharp
public static class ErrorMessages
{
    public const string ObjectNull = "Az ellenőrzött objektum nem lehet null.";
    public const string NameTooShort = "A név legalább 2 karakter legyen.";
    public const string EmailInvalid = "Az e-mail formátuma érvénytelen.";
    public const string AmountNegative = "Az egyenleg nem lehet negatív.";
}
```

### 💬 Magyarázat

- **Egységes hibaüzenetek:** nem kell a Validatorban ismételni.
- **Tiszta kód:** minden szabályhoz egy üzenet.
- **Későbbi fejlesztés:** könnyen átírható többnyelvűre.

---

## 🧩 5. Összefoglalás – Mit tanultunk?

| Fogalom                                   | Jelentés                                   | Példa                                                |
| ----------------------------------------- | ------------------------------------------ | ---------------------------------------------------- |
| **Validáció**                             | Adatok ellenőrzése a modell létrehozásakor | `Validator.Validate()`                               |
| **Kivételkezelés**                        | Hibák biztonságos kezelése                 | `throw new ValidationException(...)`                 |
| **SRP (Single Responsibility Principle)** | Egy osztály csak egy dolgot csináljon      | `Customer` adatokért, `Validator` szabályokért felel |
| **private set**                           | Csak belülről módosítható property         | `public string Name { get; private set; }`           |
| **Központosított üzenetek**               | Egy helyen tartott hibaüzenetek            | `Common/ErrorMessages.cs`                            |

---

## 🧠 6. Gyakorlófeladatok

1. **Adj hozzá új szabályt:**  
   A `Customer` e-mailje mindig `.com` végződésű legyen.

2. **Készíts új osztályt:**  
   `Product` (név, ár, raktárkészlet) és készíts hozzá saját `ProductValidator`-t.

3. **Refaktorálás:**  
   Válaszd szét a `Validator`-t külön `NameValidator`, `EmailValidator`, `AmountValidator` osztályokra.

4. **Kivétel tesztelése:**  
   Próbáld ki, mi történik, ha `Customer`-t hozol létre üres névvel vagy negatív összeggel.

---

➕ ÚJ 5. fejezet – Validáció újrafelhasználása: setter alapú megközelítés

**Cél:** megmutatni, hogy ugyanezek az elvek **nem csak konstruktorban**, hanem **property setterekben** és **más osztályokban** is alkalmazhatók.

## 5.1. Setter vs. konstruktor validálás – mikor melyik?

- **Konstruktor validálás**: biztosítja, hogy az objektum **kezdettől fogva érvényes**.
- **Setter validálás**: akkor hasznos, ha a mező **később is módosulhat** (pl. `ChangeEmail`, `Deposit/Withdraw`).
  - Ilyenkor a setter hívhatja a **ugyanazt** a `Validator`-t (pl. `Validator.ValidateEmail(value)`), így az **egyetlen helyen karbantartott** szabály mindenhol érvényes.

## 5.2. Guard clause (őrmondat) minta

- Setterben és metódusokban **első sorban** ellenőrzünk és **korán kilépünk** kivétellel, ha hiba van.
- Előnye: **rövid, jól olvasható** logika, nincsenek mélyen beágyazott `if`-ek.

## 5.3. Ugyanaz a Validator más osztályoknál

- Ha holnap készül egy `Product`, `Order`, `Employee` modell, **ugyanez a minta** alkalmazható:
  - a modell **csak adat**, a **Validator végzi** a szabályok ellenőrzését;
  - a hibaüzenetek **központiak** maradnak;
  - a kivétel **egységes** (`ValidationException`).

---

# 6. fejezet – Bővített feladatok:

**Cél:** a meglévő validálást **ipari közelítéshez** mozdítani, miközben a kód továbbra is érthető marad.

## 6.1. Name – fejlesztési ötletek

- Minimális és maximális hossz (pl. 2–80).
- Több egymást követő szóköz összevonása (normalizálás).
- Kezdő/követő szóköz tiltása (Trim kötelező).
- Kettős kötőjel (`--`) tiltása.
- Nemzetközi ékezetes betűk engedése (maradhat a `char.IsLetter` + engedélyezett írásjelek).
- Előre-hátra kötőjel: ne kezdődjön vagy végződjön kötőjellel.

## 6.2. Email – fejlesztési ötletek

- `Trim() + ToLowerInvariant()` normalizálás.
- Kötelező `@` és legalább egy `.` a domain részben.
- Nem kezdődhet/érhet véget `@`-al vagy `.`-al; ne legyen `..`.
- Engedélyezett karakterek egyszerű szűrése (tanulói szinten).
- Opcionális: `try { new MailAddress(email); }` mint gyors formaellenőrzés.

## 6.3. Amount – fejlesztési ötletek

- `amount >= 0` és maximum (pl. `<= 1_000_000m`).
- Skálázhatóság: max összeg legyen **konstans/konfiguráció**.
- Opcionális: két tizedesjegy (pénznem-szerű megkötés).
- Opcionális: **üzleti összefüggés** (pl. kezdő összeg > 0, ha prémium ügyfél).

---

# 🧪 7. fejezet – Ellenőrző kérdések (gyors kvíz)

1. Miért jobb a validálást a modell **kívül** tartani (Validator), mint szétszórni a kódban?
2. Mikor érdemes bevezetni **setter alapú** validálást?
3. Mi a **guard clause** és miért átláthatóbb?
4. Mi a különbség a `Validate(Customer)` és a `Validate(name,email,amount)` hívás között?
5. Miért előnyös a **központosított hibaüzenet**-gyűjtemény?

---

# 🧰 8. fejezet – Gyakorlati feladatok

> **Formátum:** minden feladat önállóan is elvégezhető; ajánlott sorrendben haladni. **Tipp:** commitolj gyakran, és írj rövid, érthető commit üzeneteket!

## Feladat A – Name/Email/Amount validálás bővítése

**Cél:** a 6. fejezet fejlesztési pontjainak **min. 2–2 elemét** valósítsd meg mindhárom kategóriában.  
**Követelmény:** a `Validator` metódusok (Name/Email/Amount) dobjanak **egyértelmű üzenettel** `ValidationException`-t.  
**Ellenőrzés:** írj 1–1 rövid tesztet vagy `Main`-ben mintapéldát, ami igazolja a működést.

## Feladat B – Setteres validáció egy módosító metódussal

**Cél:** készíts a `Customer`-ben egy `ChangeEmail(string newEmail)` metódust, amely:

- normalizál,
- meghívja a `Validator.ValidateEmail(newEmail)`-t,
- csak siker esetén állítja át az emailt.  
  **Ellenőrzés:** próbáld ki érvénytelen és érvényes értékkel is.

## Feladat C – Teljes objektum újraellenőrzése

**Cél:** hozz létre egy `Revalidate()` metódust a `Customer`-ben, amely a **jelenlegi állapotot** ellenőrzi:

- `Validator.Validate(this)` hívás;
- dobja tovább a kivételt, ha valami már nem felel meg a szabályoknak (pl. kézi módosítások után).

---

# 🧠 9. fejezet – Új mezők

> Ezek **nem** kötelezőek kezdő szinten, de kiváló gyakorlóprojektek.

### Feladat D – `BirthDate` (DateOnly) a Customer-hez

- **Szabályok (javaslat):**
  - Nem lehet jövőbeni dátum.
  - Legalább 14 éves legyen az ügyfél (számítsd ki életkort).
  - Opcionális: `MinAge` konstans a `Common`-ban.
- **Kihívás:** időzóna/UTC eltérések – most egyszerűsítve `DateTime.Today`-jal is elegendő.

### Feladat E – `PhoneNumber` (string) a Customer-hez

- **Szabályok (javaslat):**
  - Csak szám, szóköz, `+`, `-`, paréntézis engedett.
  - Minimum 8–10 számjegy (országkód nélkül), `+36`-os forma elfogadott.
  - Nincs két egymás utáni speciális karakter (pl. `--`, `++`).
- **Kihívás:** normalizálás tároláskor (pl. csak számjegyek + `+` prefix), megjelenítéshez külön formatter.

### Feladat F – `LoyaltyLevel` (enum) + `Discount` (számított property)

- **Szabályok (javaslat):**
  - `LoyaltyLevel` értékei: `Basic`, `Silver`, `Gold`, `Platinum`.
  - `Discount` számítása: `Basic=0%`, `Silver=5%`, `Gold=10%`, `Platinum=15%`.
  - Opcionális: a `Discount`-ot ne engedd negatív vagy 30% feletti értékűre állni.
- **Kihívás:** `Amount`-tal kombinált üzleti logika (pl. `Gold` csak ha `Amount >= 100_000m`).

## 📚 Összegzés

Ez a projekt megmutatja, hogyan lehet **objektumorientált elvek mentén** és **tiszta kódszemlélettel** megvalósítani az adatok érvényesítését.  
A diákok így már az alapoknál megtanulják:

- hogyan épül fel egy domain modell,
- hogyan védjük meg az objektumainkat hibás állapottól,
- és hogyan építünk karbantartható, ipari szemléletű kódot.