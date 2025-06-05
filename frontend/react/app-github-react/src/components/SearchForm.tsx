// src/components/SearchForm.tsx
import React, { useState } from 'react';
import ErrorMessage from './ErrorMessage';

interface SearchFormProps {
    onSearch: (username: string) => void; // Função que será chamada ao buscar
    isLoading: boolean;
    errorMessage?: string; // Mensagem de erro opcional
}

const SearchForm: React.FC<SearchFormProps> = ({ onSearch, isLoading }) => {
    const [username, setUsername] = useState<string>('');
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault(); // Previne o recarregamento da página
        if (username.trim()) {
            onSearch(username.trim());
        }
        else {
            setError('Por favor, digite um username válido.');
            console.error('Erro: Username inválido ou vazio');
        }
    };

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
        if (error) {
            setError(null); // Limpa o erro quando o usuário começa a digitar
        }
    };


    return (
      <div className="search-container">
         <form onSubmit={handleSubmit} className="search-area">
               <input
                  type="text"
                  value={username}
                  onChange={handleInputChange}
                  id="usernameInput"
                  placeholder="Digite um username do GitHub"
                  disabled={isLoading}
               />
               <button 
                  id="searchButton"
                  type="submit" disabled={isLoading}>
                  {isLoading ? 'Buscando...' : 'Buscar Perfil'}
               </button>
         </form>
         <ErrorMessage message={error} />
      </div>
    );
};

export default SearchForm;
