import { Link } from "react-router-dom";

const Home = () => {
    return (
        <div className="flex items-center justify-center min-h-screen bg-gradient-to-br from-gray-50 to-gray-200 text-gray-900">
            <div className="bg-white p-10 rounded-lg shadow-2xl max-w-lg w-full text-center">
                <h1 className="text-4xl font-extrabold text-gray-800 mb-4">
                    Rezervasyon Yönetim Sistemi
                </h1>
                <p className="text-lg text-gray-600 mb-6">
                    Kolayca rezervasyonlarınızı yönetin, yeni rezervasyon ekleyin veya mevcutları iptal edin.
                </p>
                <div className="space-y-4">
                    <Link
                        to="/reservations"
                        className="block w-full bg-indigo-600 text-white py-3 rounded-lg shadow-md hover:bg-indigo-700 transition duration-300"
                    >
                        Rezervasyonları Görüntüle
                    </Link>
                    <Link
                        to="/add"
                        className="block w-full bg-emerald-500 text-white py-3 rounded-lg shadow-md hover:bg-emerald-600 transition duration-300"
                    >
                        Yeni Rezervasyon Ekle
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default Home;
