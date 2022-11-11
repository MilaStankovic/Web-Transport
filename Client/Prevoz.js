export class Prevoz
{
    constructor(naziv, slika, cena, prosecnaZarada)
    {
        this.naziv=naziv;
        this.slika=slika;
        this.cena=cena;
        this.prosecnaZarada=prosecnaZarada;

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
        im.src=this.slika;
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
        alert("POZZZZZZZZZZZZZZ");
    }


}

var vozilo = new Prevoz("Mercedes", "../Slike/slika1.png", 180000, 2000000);
vozilo.crtajPrevoz(document.body);