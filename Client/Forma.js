import { Prevoz } from "./Prevoz.js";

export class Forma
{
    constructor()
    {
        this.cont=null;
    }

    crtajFormu(host)
    {
        if(!host)
        {
            throw new Error("Host is undefined");
        }

        this.cont=document.createElement("div");
        this.cont.className="glavniKontejner";
        host.appendChild(this.cont);

        let tmp=document.createElement("div");
        tmp.className="leviPrikaz";
        this.cont.appendChild(tmp);
        
        this.crtajRed(tmp, "zapremina", "Zapremina(cm^3): ", "number");
        this.crtajRed(tmp, "tezina", "Tezina(kg): ", "number");
        this.crtajRed(tmp, "datumPrijema", "Datum prijema: ", "date");
        this.crtajRed(tmp, "datumDostave", "Datum dostave: ", "date");
        this.crtajRed(tmp, "cenaPocetna", "Cena od: ", "number");
        this.crtajRed(tmp, "cenaKraj", "Cena do: ", "number");

        let rd=document.createElement("div");
        rd.className="divZaDugmePronadji";
        tmp.appendChild(rd);

        let pom=document.createElement("button");
        pom.className="dugmeZaPronalazak";
        pom.innerHTML="Pronadji";
        pom.onclick= ev => this.Pronadji();
        rd.appendChild(pom);

        pom=document.createElement("div");
        pom.className="desniPrikaz";
        this.cont.appendChild(pom);
    }

    crtajRed(host, nazklase, naziv, tip)
    {
        let tmp=document.createElement("div");
        tmp.className="red";
        host.appendChild(tmp);

        let pom=document.createElement("div");
        pom.className="labelaZaRed";
        pom.innerHTML=naziv;
        tmp.appendChild(pom);

        pom=document.createElement("input");
        pom.className=`nazivKlaseZajednicka ${nazklase}`;
        pom.type=tip;
        tmp.appendChild(pom);
    }

    Pronadji()
    {
        const zapremina = this.cont.querySelector(".zapremina").value;
        const tezina = this.cont.querySelector(".tezina").value;
        const cenaOd = this.cont.querySelector(".cenaPocetna").value;
        const cenaDo = this.cont.querySelector(".cenaKraj").value;

        const gdeDaCrtaVozilo = document.querySelector(".desniPrikaz"); 
        gdeDaCrtaVozilo.innerHTML="";
        
        fetch("https://localhost:5001/Vozilo/VratiVozila/" + zapremina + "/" + tezina + "/" + cenaOd + "/" + cenaDo)
            .then(p => {
                p.json().then(vozila => {
                    vozila.forEach(vozilo => {
                        var prevoz = new Prevoz(vozilo.kompanija.naziv, vozilo.slika, vozilo.cena, vozilo.kompanija.prosecnaZarada, vozilo.kompanija.id, vozilo.id);
                        prevoz.crtajPrevoz(gdeDaCrtaVozilo);
                    });
                })});
    }
}

// var komp=new Kompanija("Milina kompanija", [], 50000);
// komp.crtajKompaniju(document.body);