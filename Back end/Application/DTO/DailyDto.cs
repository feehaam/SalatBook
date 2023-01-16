namespace ApplicationLayer.DTO
{
    public class DailyDto
    {
        public DailyDto()
        {

        }
        public void set(string? date, int color, bool fozor_foroj, bool fozor_sunnat, bool johor_foroj, bool johor_sunnat, bool asor_foroj, bool asor_sunnat, bool magrib_foroj, bool magrib_sunnat, bool isha_foroj, bool isha_sunnat, bool betr, bool tahajjut)
        {
            Date = date;
            Color = color;
            Fozor_foroj = fozor_foroj;
            Fozor_sunnat = fozor_sunnat;
            Johor_foroj = johor_foroj;
            Johor_sunnat = johor_sunnat;
            Asor_foroj = asor_foroj;
            Asor_sunnat = asor_sunnat;
            Magrib_foroj = magrib_foroj;
            Magrib_sunnat = magrib_sunnat;
            Isha_foroj = isha_foroj;
            Isha_sunnat = isha_sunnat;
            Betr = betr;
            Tahajjut = tahajjut;
        }

        public string ?Date { get; set; }
        public int Color { get; set; }
        public bool Fozor_foroj { get; set; }
        public bool Fozor_sunnat { get; set; }
        public bool Johor_foroj { get; set; }
        public bool Johor_sunnat { get; set; }
        public bool Asor_foroj { get; set; }
        public bool Asor_sunnat { get; set; }
        public bool Magrib_foroj { get; set; }
        public bool Magrib_sunnat { get; set; }
        public bool Isha_foroj { get; set; }
        public bool Isha_sunnat { get; set; }
        public bool Betr { get; set; }
        public bool Tahajjut { get; set; }
    }
}

/*
NAMAJ PAIR COMBINATION
----------------------
    NN = Foroj not done, Sunnat not done
    FN = Foroj done, Sunnat not done
    FS = Foroj done, Sunnat done

Now if we combine two namaj together - 
first 2 char = namaj 1, second 2 char = namaj 2
    NNNN NNFN NNFS
    FNNN FNFN FNFS
    FSNN FSFN FSFS

In case of Fozor & Johor, 
FNFS means: FN (Fozor foroj done, Sunnat not done) and 
            FS (Johor foroj done, Sunnat done)

So,
    NNNN: 1
    NNFN: 2
    NNFS: 3
    FNNN: 4
    FNFN: 5
    FNFS: 6
    FSNN: 7 
    FSFN: 8 
    FSFS: 9

PAIRS
    Fozor + Johor
    Asor + Magrib
    Isha + Betr + Tahajjut
In case of Isha + Betr + Tahajjut, First two chars will represent Isha foroj and sunnat
and the next two will represent Betr and Tahajjut. Also, there is no combination availed 
for Betr not done, Tahajjut done. In front end, someone can mark tahajjut as done only if
he/she has completed all of the before (including Betr)

Finally, a day with value 786 means: FSNNFSFNFNFS
which means, 
    Fozor foroz done, sunnat done
    Johor foroz and sunnat not done
    Asor foroz done, sunnat done
    Magrib foriz done, sunnat not done
    Isha foroz done, sunnat not done, betr done

AND THERE WILL BE ADDITIONAL 1 NUMBER AFTER THAT FOR COLOR
AND ADDITIONAL (AT MOST 5) NUMBERS REPRESENTING DATE
*/
