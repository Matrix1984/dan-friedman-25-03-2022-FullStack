import { Administrativearea } from "./administrativearea.type";
import { Country } from "./country.type";

export interface LocationSearchResponse{
    version:number;
    key:string;
    type:string;
    rank:number;
    localizedName:string;
    country:Country;
    administrativeArea:Administrativearea;
}

 