import { Link } from "react-router-dom";

const Navbar = () => {
    return (
        <nav className="bg-gradient-to-r from-indigo-700 to-indigo-500 p-4 shadow-md">
            <div className="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-2xl font-bold text-white tracking-wide">
                    Rezervasyon Yönetimi
                </Link>
                <div className="space-x-4">
                    <Link
                        to="/reservations"
                        className="text-white text-lg hover:text-gray-300 transition duration-300"
                    >
                        Rezervasyonlar
                    </Link>
                    <Link
                        to="/add"
                        className="bg-white text-indigo-600 px-4 py-2 rounded-md shadow hover:bg-gray-100 transition duration-300"
                    >
                        + Yeni Rezervasyon
                    </Link>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;
