export class Prevoz
{
    constructor(naziv, slika, cena, prosecnaZarada, kompanijaID, voziloID)
    {
        this.naziv=naziv;
        this.slika=slika;
        this.cena=cena;
        this.prosecnaZarada=prosecnaZarada;
        this.kompanijaID=kompanijaID;
        this.voziloID=voziloID;

        this.cont=null;
    }

    crtajPrevoz(host)
    {
        if(!host)
        {
            throw new Error("Host is undefined!");
        }

        this.cont=host;

        let tmp=document.createElement("div");
        tmp.className="glavniDivZaPrevoz";
        this.cont.appendChild(tmp);

        let pom=document.createElement("div");
        pom.className="nazivPrevoza";
        pom.innerHTML=`Naziv: ${this.naziv}`;
        tmp.appendChild(pom);

        pom=document.createElement("div");
        pom.className="divZaSlikuVozila";
        tmp.appendChild(pom);

        let im=document.createElement("img");
        im.className="slikaVozila";
        im.src=`../Slike/${this.slika}`;
        pom.appendChild(im);

        pom=document.createElement("div");
        pom.className="cenaVozila";
        pom.innerHTML=`Cena: ${this.cena}`;
        tmp.appendChild(pom);

        pom=document.createElement("div");
        pom.className="zaradaFirmeVozila";
        pom.innerHTML=`Prosecna zarada: ${this.prosecnaZarada}`;
        tmp.appendChild(pom);

        pom=document.createElement("div");
        pom.className="divZaDugmeIsporuke";
        tmp.appendChild(pom);

        let btn=document.createElement("button");
        btn.innerHTML="Isporuci";
        btn.onclick= ev => this.Isporuci();
        pom.appendChild(btn);

    }

    Isporuci()
    {
        fetch("https://localhost:5001/Vozilo/RezervisiVozilo/" + this.kompanijaID + "/" + this.voziloID,{
            method:"POST"
        })  
        alert("Uspesno ste rezervisali vozilo."); 
    }
}

// var vozilo = new Prevoz("Mercedes", "../Slike/slika1.png", 180000, 2000000);
// vozilo.crtajPrevoz(document.body);