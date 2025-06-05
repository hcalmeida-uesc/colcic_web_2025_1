// src/components/UserProfileCard.tsx
import React from 'react';
import type { GitHubUserProfile } from '../services/gitHubApiService'; // Importar a interface
 // Importar a interface

interface UserProfileCardProps {
    user: GitHubUserProfile;
}

const UserProfileCard: React.FC<UserProfileCardProps> = ({ user }) => {
    return (
        <div className="profile-card">
            <img src={user.avatar_url} alt={`Avatar de ${user.login}`} />
            <div> {/* Div para agrupar o texto ao lado da imagem */}
                <h2>{user.name || user.login} ({user.login})</h2>
                {user.bio && <p><strong>Bio:</strong> {user.bio}</p>}
                <p><strong>Repositórios Públicos:</strong> {user.public_repos}</p>
                <p>
                    <strong>Seguidores:</strong> {user.followers} | <strong>Seguindo:</strong> {user.following}
                </p>
                <p>
                    <strong>Membro desde:</strong>{' '}
                    {new Date(user.created_at).toLocaleDateString('pt-BR', {
                        day: '2-digit', month: 'long', year: 'numeric'
                    })}
                </p>
                <p>
                    <a href={user.html_url} target="_blank" rel="noopener noreferrer">
                        Ver Perfil Completo no GitHub ↗
                    </a>
                </p>
            </div>
        </div>
    );
};

export default UserProfileCard;
