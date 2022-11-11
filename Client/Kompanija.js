export class Kompanija
{
    constructor(naziv, listaVozila, prosecnaZarada)
    {
        this.naziv=naziv;
        this.listaVozila=listaVozila;
        this.prosecnaZarada=prosecnaZarada;

        this.cont=null;
    }

    crtajKompaniju(host)
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

        let pom=document.createElement("div");
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
}

var komp=new Kompanija("Milina kompanija", [], 50000);
komp.crtajKompaniju(document.body);