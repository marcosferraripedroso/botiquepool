import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'cadastro',
    templateUrl: './cadastro.component.html'
})
export class CadastroComponent {
    public pessoa: PessoaGrid[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

  

    }

   
}


     


interface PessoaGrid {
    nome: string;
    email: number;
    idade: number;
    profissao: string;
    desempregado: boolean;
}
