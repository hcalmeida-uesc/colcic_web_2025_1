// src/components/ErrorMessage.tsx
import React from 'react';

interface ErrorMessageProps {
    message: string | null;
}

const ErrorMessage: React.FC<ErrorMessageProps> = ({ message }) => {
    if (!message) {
        return null; // Não renderiza nada se não houver mensagem
    }
    return <div className="error-message">{message}</div>;
};

export default ErrorMessage;
