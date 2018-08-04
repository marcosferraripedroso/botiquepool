import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'lista',
    templateUrl: './lista.component.html'
})
export class ListaComponent {
    public pessoas: PessoaGrid[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('http://localhost:49596/home/GetLista').subscribe(result => {
            this.pessoas = JSON.parse(result.json()) as PessoaGrid[];
        }, error => console.error(error));
    }
}

interface PessoaGrid {
    Nome: string;
    Email: number;
    Idade: number;
    Profissao: string;
    Status: boolean;
}
