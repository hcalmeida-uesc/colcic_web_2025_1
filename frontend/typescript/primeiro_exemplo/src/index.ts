interface Produto {
    readonly id: number; // Não pode ser alterado após a criação
    nome: string;
    preco: number;
    descricao?: string; // Propriedade opcional
    calcularDesconto(percentual: number): number;
}

let livro: Produto = {
    id: 101,
    nome: "O Senhor dos Anéis",
    preco: 59.90,
    // descricao: "Uma grande aventura.", // Opcional
    calcularDesconto(percentual: number): number {
        return this.preco * (1 - percentual / 100);
    }
};
// livro.id = 102; // Erro! 'id' é readonly.
console.log(livro.nome);
console.log(`Preço com 10% de desconto: ${livro.calcularDesconto(10).toFixed(2)}`);

function exibirProduto(p: Produto): void {
    console.log(`${p.nome} (ID: <span class="math-inline">\{p\.id\}\) \- R</span> ${p.preco.toFixed(2)}`);
}
exibirProduto(livro);
