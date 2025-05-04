import * as ClassicEditor from 'ckeditor5';

document.addEventListener('DOMContentLoaded', () => {
    ClassicEditor.ClassicEditor.create(document.querySelector('#FinalResult'), {
        licenseKey: '',
        toolbar: [
            'heading', '|', 'bold', 'italic', 'fontSize', 'fontColor', 'fontBackgroundColor', '|',
            'link', 'bulletedList', 'numberedList', '|',
            'alignment:left', 'alignment:center', 'alignment:right', 'alignment:justify'
        ],
        language: 'fa',
        ui: { language: 'fa' },
        contentLanguage: 'fa',
        alignment: {
            options: ['left', 'right', 'center', 'justify']
        }
    })
        .then(editor => {
            editor.model.document.on('change:data', () => {
                const htmlContent = editor.getData();
                // می‌توانید اینجا پردازش‌های دلخواه روی htmlContent انجام دهید
            });
        })
        .catch(error => {
            console.error('Error initializing the editor:', error);
        });
});
