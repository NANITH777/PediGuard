<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Récupérer les données du formulaire
    $name = $_POST['name'];
    $email = $_POST['email'];
    $subject = $_POST['subject'];
    $message = $_POST['message'];

    // Destinataire
    $to = "lussnanith7755@gmail.com";
    // Sujet de l'email
    $email_subject = "Message from $name: $subject";
    // Corps du message
    $email_body = "You have received a new message from your website contact form.\n\n".
                  "Here are the details:\n\n".
                  "Name: $name\n".
                  "Email: $email\n".
                  "Subject: $subject\n".
                  "Message:\n$message";

    // En-têtes de l'email
    $headers = "From: $email\n";
    $headers .= "Reply-To: $email\n";

    // Envoi de l'email
    if (mail($to, $email_subject, $email_body, $headers)) {
        echo "Message sent successfully!";
    } else {
        echo "Failed to send the message.";
    }
}
?>

