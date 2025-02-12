import { useState } from "react";
import { useNavigate } from "react-router-dom";
import API from "../api/API"; // API.js dosyasını kullanıyoruz

const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        setError("");

        const loginData = {
            email: email, // Küçük harf ile gönderiyoruz (Swagger ile aynı!)
            password: password,
        };

        console.log("📢 Gönderilen JSON:", JSON.stringify(loginData));

        try {
            const response = await API.post("/auth/login", loginData, {
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                },
            });

            console.log("✅ Gelen Yanıt:", response.data);

            const token = response.data.token;
            localStorage.setItem("token", token);
            navigate("/reservations");
        } catch (err) {
            console.error("❌ Login Hatası:", err);
            setError("Giriş başarısız. Lütfen bilgilerinizi kontrol edin.");
        }
    };



    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
                <h1 className="text-2xl font-semibold text-center text-gray-700 mb-6">
                    Kullanıcı Girişi
                </h1>

                {error && <div className="mb-4 p-3 text-center text-white bg-red-500 rounded">{error}</div>}

                <form onSubmit={handleLogin} className="space-y-4">
                    <div>
                        <label className="block text-gray-600 font-medium">E-posta</label>
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            className="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
                            placeholder="E-posta adresinizi girin"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-gray-600 font-medium">Şifre</label>
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            className="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
                            placeholder="Şifrenizi girin"
                            required
                        />
                    </div>
                    <button
                        type="submit"
                        className="w-full bg-indigo-600 text-white py-2 rounded-lg hover:bg-indigo-700 transition duration-300"
                    >
                        Giriş Yap
                    </button>
                </form>
            </div>
        </div>
    );
};

export default Login;
