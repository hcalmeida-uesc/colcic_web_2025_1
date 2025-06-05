// src/App.tsx
import { useState } from 'react';
import type { GitHubUserProfile } from './services/gitHubApiService';
import { fetchGitHubUserProfile } from './services/gitHubApiService';
import SearchForm from './components/SearchForm';
import UserProfileCard from './components/UserProfileCard';
import ErrorMessage from './components/ErrorMessage';
import LoadingIndicator from './components/LoadingIndicator';
import './style.css'; // Importar o CSS global

function App() {
    const [userProfile, setUserProfile] = useState<GitHubUserProfile | null>(null);
    const [error, setError] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    const handleSearch = async (username: string) => {
        setIsLoading(true);
        setUserProfile(null);
        setError(null);

        try {
            const profile = await fetchGitHubUserProfile(username);
            setUserProfile(profile);
        } catch (err) {
            if (err instanceof Error) {
                setError(err.message);
            } else {
                setError('Ocorreu um erro desconhecido.');
            }
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="container">
            <h1>Visualizador de Perfil do GitHub com React</h1>
            <p>Digite um nome de usuário do GitHub para ver suas informações.</p>

            <SearchForm onSearch={handleSearch} isLoading={isLoading} />

            {isLoading && <LoadingIndicator />}
            {error && <ErrorMessage message={error} />}
            {userProfile && !isLoading && <UserProfileCard user={userProfile} />}
        </div>
    );
}

export default App;
