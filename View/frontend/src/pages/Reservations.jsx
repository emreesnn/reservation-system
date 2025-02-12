import { useEffect, useState } from "react";
import API from "../api/API";

const Reservations = () => {
    const [reservations, setReservations] = useState([]);
    const [message, setMessage] = useState(""); // Bildirim mesajı için state

    useEffect(() => {
        API.get("/appointments/GetAppointments")
            .then(response => setReservations(response.data))
            .catch(error => console.error("Hata:", error));
    }, []);

    // Rezervasyonu iptal etme (onaylı + mesajlı)
    const handleCancel = async (id) => {
        const confirmCancel = window.confirm("Bu rezervasyonu iptal etmek istediğinizden emin misiniz?");
        if (!confirmCancel) return;

        try {
            await API.delete(`/appointments/DeleteAppointment/${id}`);
            setReservations(reservations.filter(reservation => reservation.id !== id));
            setMessage("Rezervasyon başarıyla iptal edildi."); // Başarı mesajı
            setTimeout(() => setMessage(""), 3000); // 3 saniye sonra mesajı kaldır
        } catch (error) {
            console.error("Rezervasyon iptal edilirken hata oluştu:", error);
            setMessage("Bir hata oluştu. Lütfen tekrar deneyin.");
            setTimeout(() => setMessage(""), 3000);
        }
    };

    return (
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
            <div className="bg-white p-8 rounded-lg shadow-2xl w-full max-w-3xl">
                <h1 className="text-3xl font-semibold text-center text-gray-800 mb-6">
                    Rezervasyonlar
                </h1>

                {message && (
                    <div className={`mb-4 p-3 text-center text-white rounded ${message.includes("hata") ? "bg-red-500" : "bg-green-500"}`}>
                        {message}
                    </div>
                )}

                {reservations.length === 0 ? (
                    <p className="text-gray-600 text-center">Henüz rezervasyon yok.</p>
                ) : (
                    <table className="w-full border-collapse border border-gray-300 shadow-lg">
                        <thead>
                            <tr className="bg-indigo-600 text-white">
                                <th className="p-3 border border-gray-300">İsim</th>
                                <th className="p-3 border border-gray-300">Tarih</th>
                                <th className="p-3 border border-gray-300">İşlem</th>
                            </tr>
                        </thead>
                        <tbody>
                            {reservations.map((reservation) => (
                                <tr key={reservation.id} className="text-center odd:bg-gray-100 even:bg-white">
                                    <td className="p-3 border border-gray-300">{reservation.name}</td>
                                    <td className="p-3 border border-gray-300">{reservation.date}</td>
                                    <td className="p-3 border border-gray-300">
                                        <button
                                            onClick={() => handleCancel(reservation.id)}
                                            className="bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-700 transition duration-300"
                                        >
                                            İptal Et
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                )}
            </div>
        </div>
    );
};

export default Reservations;
